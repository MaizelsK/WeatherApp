using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WeatherApp
{
    public class ForecastView
    {
        public string Date { get; set; }
        public BitmapImage Image { get; set; } 
        public string Temperature { get; set; }
        public string WindSpeed { get; set; }
    }
}
