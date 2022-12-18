using Framework.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace Framework.Selenium
{
    public static class Driver
    {
        [ThreadStatic]
        private static IWebDriver _driver;

        [ThreadStatic]
        public static Window Window;

        [ThreadStatic]
        public static Wait Wait;

        [ThreadStatic]
        public static DirectoryInfo CurrentTestDirectory;

        public static void Init()
        {
            _driver = DriverFactory.Build(Settings.BrowserName);
            Wait = new Wait(Settings.Timeout);
            Window = new Window();
            Window.Maximize();
        }

        public static IWebDriver Current => _driver ?? throw new NullReferenceException("_driver is null.");

        public static void Goto(string url)
        {
            if (!url.StartsWith("http"))
            {
                url = $"http://{url}";
            }

            Current.Navigate().GoToUrl(url);
        }

        public static IWebElement FindElement(By by)
        {
            return Wait.Until(Current => Current.FindElement(by));          
        }

        public static IReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return Wait.Until(Current => Current.FindElements(by));
        }

        public static void TakeScreenshot(string imageName)
        {
            var testResultsDir = Path.GetFullPath(@"../../../../") + Settings.ScreenShotPath;
            var testName = TestContext.CurrentContext.Test.Name;
            var fullPath = $"{testResultsDir}/{testName}";

            if (Directory.Exists(fullPath))
            {
                CurrentTestDirectory = Directory.CreateDirectory(fullPath + TestContext.CurrentContext.Test.ID);
            }
            else
            {
                CurrentTestDirectory = Directory.CreateDirectory(fullPath);
            }

            var ss = ((ITakesScreenshot)Current).GetScreenshot();
            var ssFileName = Path.Combine(CurrentTestDirectory.FullName, imageName);
            ss.SaveAsFile($"{ssFileName}.png", ScreenshotImageFormat.Png);
        }

        public static void Quit()
        {
            Current.Quit();
        }

    }
}
