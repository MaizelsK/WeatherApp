using Newtonsoft.Json;

namespace WeatherApp.YahooAPI
{
    public class Channel
    {
        [JsonProperty("wind")]
        public Wind Wind { get; set; }

        [JsonProperty("item")]
        public Item Item { get; set; }
    }
}