using BaseUIBDD.Common;
using BaseUIBDD.Pageobjects;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace BaseUIBDD.Steps
{
    [Binding]
    public sealed class Home
    {
        private readonly HomePageObject _homePageObject;

        public Home()
        {
            if (_homePageObject == null)
            {
                _homePageObject = new HomePageObject(WebBrowser.Driver);
            }
        }


        [Given(@"Launch a browser with url ""(.*)""")]
        public void GivenLaunchABrowserWithUrl(string url)
        {
            _homePageObject.NavigateToUrl(url);

            _homePageObject.PageTitle().Should().NotBeNullOrWhiteSpace();
        }
    }
}
