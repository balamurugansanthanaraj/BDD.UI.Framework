using BaseUIBDD.Common;
using BaseUIBDD.CustomTypes;
using OpenQA.Selenium;

namespace BaseUIBDD.Pageobjects
{
    public class HomePageObject : BasePageObject
    {
        private readonly IWebDriver _webDriver;

        private const string Gobutton = "btnG";
        private const string NextButton = "pnnext";
        private const string SearchBox = "lst-ib";
        
        public HomePageObject(IWebDriver webDriver) : base(webDriver)
        {
            _webDriver = webDriver;
        }

        public bool SearchText(string searchTerm)
        {
            return base.SearchText(searchTerm, SearchBox);
        }

        public bool ClickGoButton()
        {
            return base.ClickElement(Gobutton);
        }

        public bool GoToNextpage()
        {
            CommonPage.ScrollToBottom(_webDriver);
            CommonPage.Pause();
            return CommonPage.ClickElement(_webDriver, NextButton, ByElementType.Id, 40);
        }
    }
}
