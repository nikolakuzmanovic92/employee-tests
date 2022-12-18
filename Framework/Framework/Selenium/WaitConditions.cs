using System;
using OpenQA.Selenium;

namespace Framework.Selenium
{
    public sealed class WaitConditions
    {
        public static Func<IWebDriver, bool> ElementDisplayed(IWebElement element)
        {
            bool condition(IWebDriver driver)
            {
                return element.Displayed;
            }

            return condition;
        }

        public static Func<IWebDriver, IWebElement> ElementIsDisplayed(IWebElement element)
        {
            IWebElement condition(IWebDriver driver)
            {
                try
                {
                    return element.Displayed ? element : null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
                catch (ElementNotVisibleException)
                {
                    return null;
                }
            }

            return condition;
        }

        public static Func<IWebDriver, bool> ElementNotDisplayed(IWebElement element)
        {
            bool condition(IWebDriver driver)
            {
                try
                {
                    return !element.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return true;
                }
            }

            return condition;
        }

        public static Func<IWebDriver, bool> UrlContains(string keyword)
        {
            bool condition(IWebDriver driver)
            {
                return driver.Url.Contains(keyword);
            }

            return condition;
        }

        public static Func<IWebDriver, IAlert> AlertDisplayed()
        {
            IAlert condition(IWebDriver driver)
            {
                try
                {
                    return driver.SwitchTo().Alert();
                }
                catch (NoAlertPresentException e)
                {
                    return null;
                }
            }
            return condition;
        }
    }
}
