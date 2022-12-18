using Microsoft.Extensions.Configuration;
using System.IO;



namespace Framework.Configuration
{
    public class ConfigReader
    {
        public static void SetFrameworkSettings()
        {

            var builder = new ConfigurationBuilder().SetBasePath(Path.GetFullPath(@"../../../../Tests/")).AddJsonFile("appsettings.json");


            IConfigurationRoot configurationRoot = builder.Build();

            Settings.Environment = configurationRoot.GetSection("testSettings").Get<TestSettings>().Environment;
            Settings.URL = configurationRoot.GetSection("testSettings").Get<TestSettings>().URL;
            Settings.TestType = configurationRoot.GetSection("testSettings").Get<TestSettings>().TestType;       
            Settings.BrowserName = configurationRoot.GetSection("testSettings").Get<TestSettings>().Browser;
            Settings.Timeout = configurationRoot.GetSection("testSettings").Get<TestSettings>().Timeout;
            Settings.ScreenShotPath = configurationRoot.GetSection("testSettings").Get<TestSettings>().ScreenShotPath;

        }

    }
}
