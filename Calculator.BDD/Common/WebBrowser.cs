using System;
using System.Diagnostics;
using System.IO;
using System.Web.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BaseUIBDD.Common
{
    public static class WebBrowser
    {
        private static IWebDriver _driver;

        public static IWebDriver Driver
        {
            get
            {
                if (_driver != null) return _driver;

                Console.WriteLine("Create Instance Driver");

                var driverExePath = CustomConfiguration.ChromeDriverPath;
                var portableExePath = CustomConfiguration.GoogleChromePortable;
                var defaultProfilePath = CustomConfiguration.GoogleChromeDefaultProfilePath;

                var options = new ChromeOptions { BinaryLocation = portableExePath };
                options.AddArgument("start-maximized");
                options.AddArgument("user-data-dir=" + defaultProfilePath);
                //options.AddArgument("localState");

                _driver = string.IsNullOrWhiteSpace(portableExePath)
                            ? new ChromeDriver(driverExePath)
                            : new ChromeDriver(driverExePath, options, TimeSpan.FromMinutes(1));


                _driver
                    .Manage()
                    .Timeouts()
                    .SetPageLoadTimeout(TimeSpan.FromSeconds(20));

                _driver
                    .Manage()
                    .Timeouts()
                    .SetScriptTimeout(TimeSpan.FromSeconds(20));

                return _driver;
            }
        }

        public static void Quit()
        {
            if (_driver == null) return;

            try
            {
                _driver.Close();
                Console.WriteLine("Closed Properly.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"****Error Occured****, Error Message: {ex.Message}");
            }
            finally
            {
                _driver.Quit();
                Console.WriteLine("Quit Browser");
                _driver = null;
                KillProccesses();
                DeleteFolder();
            }
        }

        private static void DeleteFolder()
        {
            var defaultProfilePath = WebConfigurationManager.AppSettings["DefaultProfile"];

            if (!Directory.Exists(defaultProfilePath))
            {
                Console.WriteLine("Not Present");
                return;
            }

            try
            {
                Console.WriteLine("File Deleted Guys");

                var di = new DirectoryInfo(defaultProfilePath);

                Console.WriteLine("Name -" + di.Name);

                DeleteDirectoryfiles(di);

                foreach (var dir in di.GetDirectories("*"))
                {
                    try
                    {
                        Console.WriteLine("Directory Name -" + dir.FullName);

                        var dirInfo = new DirectoryInfo(dir.FullName);

                        DeleteDirectoryfiles(dirInfo);

                        dirInfo.Delete(true);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.InnerException);
                    }
                }

                //di.Delete(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        private static void DeleteDirectoryfiles(DirectoryInfo di)
        {
            foreach (var file in di.GetFiles("*"))
            {
                try
                {
                    Console.WriteLine("File Name -" + file.FullName);

                    file.Delete();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        private static void KillProccesses()
        {
            var allProcesses = Process.GetProcessesByName("chrome");

            foreach (var process in allProcesses)
            {
                try
                {
                    process.Kill();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }
    }
}
