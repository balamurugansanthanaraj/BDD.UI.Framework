using System.Threading;
using BaseUIBDD.Common;
using BaseUIBDD.CustomTypes;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BaseUIBDD.Pageobjects
{
    public class LoginPageObject : BasePageObject
    {
        private readonly IWebDriver _webDriver;

        [FindsBy(How = How.Id, Using = "Email")]
        private IWebElement _email;

        [FindsBy(How = How.Id, Using = "next")]
        private IWebElement _next;

        [FindsBy(How = How.Id, Using = "Passwd")]
        private IWebElement _password;

        [FindsBy(How = How.Id, Using = "signIn")]
        private IWebElement _signin;

        public LoginPageObject(IWebDriver webDriver) : base(webDriver)
        {
            _webDriver = webDriver;
            PageFactory.InitElements(webDriver, this);
        }

        public void Login()
        {
            // Set user name
            _email.SendKeys("****");
            _next.Click();
            
            // Replace **** with password
            CommonPage.EnterText(_webDriver, "Passwd", "****", ByElementType.Id);

            _signin.Click();
        }
    }
}