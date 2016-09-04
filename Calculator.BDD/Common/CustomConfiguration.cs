using System;
using System.Web.Configuration;

namespace BaseUIBDD.Common
{
    public static class CustomConfiguration
    {
        public static string ChromeDriverPath => WebConfigurationManager.AppSettings["DriverExe"];

        public static string GoogleChromePortable => WebConfigurationManager.AppSettings["PortableExe"];

        public static string GoogleChromeDefaultProfilePath => WebConfigurationManager.AppSettings["DefaultProfile"];

        public static string ScreenShotLocation
        {
            get
            {
                var location = AppDomain.CurrentDomain.BaseDirectory + @"\" +
                                  WebConfigurationManager.AppSettings["ScreenShotLocation"];

                return location;
            }
        }
    }
}
