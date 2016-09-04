using BaseUIBDD.CustomTypes;
using OpenQA.Selenium;

namespace BaseUIBDD.Common
{
    internal static class CommonPageHelper
    {
        internal static By GetByElement(ByElementType checkType, string elementToFind)
        {
            By value = null;
            switch (checkType)
            {

                case ByElementType.ClassName:
                    value = By.ClassName(elementToFind);
                    break;

                case ByElementType.CssSelector:
                    value = By.CssSelector(elementToFind);
                    break;

                case ByElementType.Id:
                    value = By.Id(elementToFind);
                    break;

                case ByElementType.LinkText:
                    value = By.LinkText(elementToFind);
                    break;

                case ByElementType.Name:
                    value = By.Name(elementToFind);
                    break;

                case ByElementType.PartialLinkText:
                    value = By.PartialLinkText(elementToFind);
                    break;

                case ByElementType.TagName:
                    value = By.TagName(elementToFind);
                    break;

                case ByElementType.XPath:
                    value = By.XPath(elementToFind);
                    break;
            }

            return value;
        }
    }
}
