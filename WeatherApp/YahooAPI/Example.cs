using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.YahooAPI
{
    public class Example
    {
        [JsonProperty("query")]
        public Query Query { get; set; }
    }
}
