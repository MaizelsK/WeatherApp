using Newtonsoft.Json;
using System.Collections.Generic;

namespace WeatherApp.YahooAPI
{
    public class Results
    {
        [JsonProperty("channel")]
        public IList<Channel> Channel { get; set; }
    }
}