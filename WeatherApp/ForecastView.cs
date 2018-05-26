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
        public string Temperature { get; set; }
        public string WindSpeed { get; set; }

        public BitmapImage WeatherImage { get; set; }
        public BitmapImage TempImage { get; set; }
        public BitmapImage WindImage { get; set; }

        public ForecastView()
        {
            TempImage = new BitmapImage(new Uri("icons\\termometr.png", UriKind.RelativeOrAbsolute));
            WindImage = new BitmapImage(new Uri("icons\\wind speed.png", UriKind.RelativeOrAbsolute));
        }
    }
}
