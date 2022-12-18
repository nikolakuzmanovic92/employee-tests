using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Framework.Selenium
{
    public class Wait
    {
        private readonly WebDriverWait _wait;

        public Wait(int waitSeconds)
        {
            _wait = new WebDriverWait(Driver.Current, TimeSpan.FromSeconds(waitSeconds))
            {
                PollingInterval = TimeSpan.FromMilliseconds(500)
            };

            _wait.IgnoreExceptionTypes(
                typeof(NoSuchElementException),
                typeof(ElementNotVisibleException),
                typeof(StaleElementReferenceException)
            );
        }

        public bool Until(Func<IWebDriver, bool> condition)
        {
            return _wait.Until(condition);
        }

        public IWebElement Until(Func<IWebDriver, IWebElement> condition)
        {
            return _wait.Until(condition);
        }

        public Object Until(Func<IWebDriver, Object> condition)
        {
            return _wait.Until(condition);
        }

        public IReadOnlyCollection<IWebElement> Until(Func<IWebDriver, IReadOnlyCollection<IWebElement>> condition)
        {
            return _wait.Until(condition);
        }
    }
}
