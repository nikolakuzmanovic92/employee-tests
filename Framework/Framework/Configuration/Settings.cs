using Framework.Selenium;

namespace Framework.Configuration
{
    public class Settings
    {
        public static string Environment { get; set; }

        public static string URL { get; set; }

        public static BrowserName BrowserName { get; set; }

        public static int Timeout { get; set; }

        public static string TestType { get; set; }

        public static string ScreenShotPath { get; set; }

    }
}
