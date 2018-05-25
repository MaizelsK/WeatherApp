using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.YahooAPI
{
    public class Query
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("results")]
        public Results Results { get; set; }
    }
}
