using Newtonsoft.Json;
using Framework.Selenium;

namespace Framework.Configuration
{
    [JsonObject("testSettings")]
    public class TestSettings
    {

        [JsonProperty("environment")]
        public string Environment { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }

        [JsonProperty("browser")]
        public BrowserName Browser { get; set; }

        [JsonProperty("timeout")]
        public int Timeout { get; set; }

        [JsonProperty("testType")]
        public string TestType { get; set; }

        [JsonProperty("screenShotPath")]
        public string ScreenShotPath { get; set; }
    }
}
