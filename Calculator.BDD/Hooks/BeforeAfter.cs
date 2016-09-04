using System;
using BaseUIBDD.Common;
using TechTalk.SpecFlow;

namespace BaseUIBDD.Hooks
{
    [Binding]
    public class BeforeAfter
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        #region Scenario
        [BeforeScenario]
        public static void BeforeScenario()
        {
            Console.WriteLine("Before Scenario");
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            Console.WriteLine("After Scenario");
            WebBrowser.Quit();
        }
        #endregion

        #region Feature
        [BeforeFeature]
        public static void BeforeFeature()
        {
            Console.WriteLine("Before Feature");
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            Console.WriteLine("After Feature");
        }
        #endregion

        #region Test Run
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Console.WriteLine("BeforeTestRun");

            var startup = new Startup.Startup();
            startup.Validate();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Console.WriteLine("AfterTestRun");
        }
        #endregion

        [AfterStep]
        public void Error()
        {
            var fileName = ScenarioContext.Current.ScenarioInfo.Title;

            if (ScenarioContext.Current.TestError != null)
            {
                CommonPage.TakeScreenShot(WebBrowser.Driver, fileName);
            }
        }
    }
}
