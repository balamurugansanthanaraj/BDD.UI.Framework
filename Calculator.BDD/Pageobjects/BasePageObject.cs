using BaseUIBDD.Common;
using BaseUIBDD.CustomTypes;
using OpenQA.Selenium;

namespace BaseUIBDD.Pageobjects
{
    public abstract class BasePageObject
    {
        private readonly IWebDriver _driver;

        protected BasePageObject(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        public void NavigateToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        protected bool SearchText(string searchTerm, string findElement)
        {
            return CommonPage.EnterText(_driver, findElement, searchTerm, ByElementType.Id, 40);
        }

        protected bool ClickElement(string findElement)
        {
            return CommonPage.ClickElement(_driver, findElement, ByElementType.Name, 40);
        }

        public string PageTitle()
        {
            return _driver.Title;
        }
    }
}
