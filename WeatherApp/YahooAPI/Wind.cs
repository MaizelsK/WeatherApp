using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace WeatherApp.YahooAPI
{
    public class Wind
    {
        [JsonProperty("chill")]
        public string Chill { get; set; }

        [JsonProperty("direction")]
        public string Direction { get; set; }

        [JsonProperty("speed")]
        public string Speed { get; set; }
    }
}