using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Framework.Selenium
{
    class DriverFactory
    {
        public static IWebDriver Build(BrowserName browserName)
        {

            switch (browserName)
            {
                case BrowserName.Chrome:
                    return new ChromeDriver();

                case BrowserName.Firefox:
                    return new FirefoxDriver();

                default:
                    throw new System.ArgumentException("Requested browser not supported.");
            }
        }
    }
}
