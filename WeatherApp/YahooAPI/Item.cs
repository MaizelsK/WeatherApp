using Newtonsoft.Json;

namespace WeatherApp.YahooAPI
{
    public class Item
    {
        [JsonProperty("condition")]
        public Condition Condition { get; set; }

        [JsonProperty("forecast")]
        public Forecast Forecast { get; set; }
    }
}