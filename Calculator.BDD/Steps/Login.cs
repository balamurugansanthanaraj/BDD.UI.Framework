using BaseUIBDD.Common;
using BaseUIBDD.Pageobjects;
using TechTalk.SpecFlow;

namespace BaseUIBDD.Steps
{
    [Binding]
    public sealed class Login
    {
        private readonly LoginPageObject _loginPageObject;

        public Login()
        {
            if (_loginPageObject == null)
            {
                _loginPageObject = new LoginPageObject(WebBrowser.Driver);
            }
        }

        [Given(@"I Login")]
        public void GivenILogin()
        {
            _loginPageObject.Login();
        }
    }
}
