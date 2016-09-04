using System;
using System.Collections.Generic;
using BaseUIBDD.Common;
using BaseUIBDD.Pageobjects;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BaseUIBDD.Steps
{
    [Binding]
    public sealed class Menu
    {
        private readonly MenuPageObject _menuPageObject;

        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef
        public Menu()
        {
            if (_menuPageObject == null)
            {
                _menuPageObject = new MenuPageObject(WebBrowser.Driver);
            }
        }

        [Given(@"I select '(.*)' from the menu")]
        public void GivenISelectFromTheMenu(string menuName)
        {
            _menuPageObject.NavigateToMenu(menuName);
        }

        [Given(@"I select following items from the menu")]
        public void GivenISelectFollowingItemsFromTheMenu(Table table)
        {
            var menus = table.CreateSet<KeyValuePair<string, string>>();

            foreach (var row in table.Rows)
            {
                Console.WriteLine("Menu :" + row[0]);

                _menuPageObject.NavigateToMenu(row[0]);
            }
        }
    }
}
