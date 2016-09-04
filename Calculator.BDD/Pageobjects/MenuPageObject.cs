using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BaseUIBDD.Pageobjects
{
    public class MenuPageObject : BasePageObject
    {
        [FindsBy(How = How.Id, Using = "ctl00_TopNavBar_Home")] private IWebElement _home;

        [FindsBy(How = How.Id, Using = "ctl00_TopNavBar_Art")] private IWebElement _articles;

        [FindsBy(How = How.Id, Using = "ctl00_TopNavBar_Answers")] public IWebElement QuickAnswer;

        [FindsBy(How = How.Id, Using = "ctl00_TopNavBar_Forums")] public IWebElement Discussions;

        [FindsBy(How = How.Id, Using = "ctl00_TopNavBar_Help")] private IWebElement _help;

        public MenuPageObject(IWebDriver webDriver) : base(webDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }

        public void NavigateToMenu(string menuName)
        {
            switch (menuName.ToLower())
            {
                case "help":
                    _help.Click();
                    break;

                case "home":
                    _home.Click();
                    break;

                case "articles":
                    _articles.Click();
                    break;
            }
        }
    }
}
