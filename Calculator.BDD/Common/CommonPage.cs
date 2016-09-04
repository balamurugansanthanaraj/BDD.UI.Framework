using System;
using System.Drawing.Imaging;
using System.Threading;
using BaseUIBDD.CustomTypes;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BaseUIBDD.Common
{
    public static class CommonPage
    {
        private static IWait<IWebDriver> _wait;
        private const int TimeinSecond = 20;

        private static char[] _restrictedCharacters = { '.', '/', '$', '@', '*' };

        public static bool EnterText(IWebDriver webDriver,
                                                string idToFind,
                                                string text,
                                                ByElementType checkType,
                                                int timeInSeconds = TimeinSecond)
        {
            var isTextEntered = false;

            try
            {
                var webElement = FindElement(webDriver, idToFind, checkType, timeInSeconds);
                if (webElement != null)
                {
                    webElement.SendKeys(text);
                    isTextEntered = true;
                }
                else
                {
                    Console.WriteLine("No element exists By Id: {0}, Method: {1}", idToFind, "CommonPage.SearchText");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occured For Id:{0}, ErrorMessage:{1}, Method: {2}",
                    idToFind,
                    ex.InnerException,
                    "CommonPage.SearchText");
            }

            return isTextEntered;
        }

        public static bool ClickElement(IWebDriver webDriver,
                                                   string idToFind,
                                                   ByElementType checkType,
                                                   int timeInSeconds = TimeinSecond)
        {
            var isClicked = false;

            try
            {
                var webElement = FindElement(webDriver, idToFind, checkType, timeInSeconds);
                if (webElement != null)
                {
                    webElement.Click();
                    isClicked = true;
                }
                else
                {
                    Console.WriteLine("No element exists By Id: {0}, Method: {1}", idToFind, "CommonPage.ClickGoButton");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occured For Id:{0}, ErrorMessage:{1}, Method: {2}",
                    idToFind,
                    ex.InnerException,
                    "CommonPage.ClickGoButton");
            }

            return isClicked;
        }

        public static void ScrollToBottom(IWebDriver webDriver)
        {
            var js = (IJavaScriptExecutor)webDriver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
        }

        public static void Pause(int timeInMillSecs = 5000)
        {
            Thread.Sleep(timeInMillSecs);
        }

        public static void TakeScreenShot(IWebDriver driver, string fileName)
        {
            fileName = FilterFileName(fileName);

            fileName = CustomConfiguration.ScreenShotLocation + @"\\" + fileName;

            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(fileName, ImageFormat.Png);
        }
        
        #region Helper Methods

        private static string FilterFileName(string fileName)
        {
            if (fileName.Length > 50)
            {
                fileName = fileName.Substring(0, 50);
            }

            foreach (var restrictedCharacter in _restrictedCharacters)
            {
                fileName = fileName.Replace(restrictedCharacter, '_');
            }

            return fileName + ".png";
        }

        private static bool CheckElementExists(IWebDriver webDriver, 
                                                          string elementToFind, 
                                                          ByElementType checkType, 
                                                          int timeinSeconds = TimeinSecond)
        {
            var elementFound = false;

            try
            {
                _wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeinSeconds));

                var by = CommonPageHelper.GetByElement(checkType, elementToFind);

                elementFound = _wait.Until(ExpectedConditions.ElementExists(by)) != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occured For Id:{0}, ErrorMessage:{1}, Method: {2}",
                    elementToFind,
                    ex.InnerException,
                    "CommonPage.CheckElementExists");
            }

            return elementFound;
        }

        private static IWebElement FindElement(IWebDriver webDriver, 
                                                          string elementToFind, 
                                                          ByElementType checkType, 
                                                          int timeInSeconds = TimeinSecond)
        {
            IWebElement webElement = null;

            try
            {
                var checkElementExists = CheckElementExists(webDriver, elementToFind, checkType, timeInSeconds);
                if (checkElementExists)
                {
                    var by = CommonPageHelper.GetByElement(checkType, elementToFind);
                    webElement = webDriver.FindElement(by);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occured For Id:{0}, ErrorMessage:{1}, Method: {2}",
                    elementToFind,
                    ex.InnerException,
                    "CommonPage.FindElement");

                webElement = null;
            }
            return webElement;
        }
        #endregion
    }
}
