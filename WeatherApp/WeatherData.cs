using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using WeatherApp.YahooAPI;

namespace WeatherApp
{
    public static class WeatherData
    {
        public static Task<Example> GetForecastData(string cityName)
        {
            return Task.Run(() =>
            {
                string requestString = "https://query.yahooapis.com/v1/public/yql?q="
                + "select wind, item.condition, item.forecast from weather.forecast where woeid in (select woeid from geo.places(1) where text='" +
                cityName +
                "') and u='c'&format=json";

                byte[] response;

                using (var client = new WebClient())
                {
                    response = client.DownloadData(requestString);
                }

                string data = Encoding.UTF8.GetString(response);

                Example query = JsonConvert.DeserializeObject<Example>(data);

                return query;
            });
        }

        public static List<ForecastView> GetForecastList(Example forecasts)
        {
                List<ForecastView> newForecastViews = new List<ForecastView>();

                for (int i = 0; i < 7; i++)
                {
                    Forecast forecast = forecasts.Query.Results.Channel[i].Item.Forecast;
                    Wind wind = forecasts.Query.Results.Channel[i].Wind;

                    newForecastViews.Add(new ForecastView
                    {
                        Date = forecast.Date,
                        Temperature = forecast.High + " °C",
                        WindSpeed = wind.Speed + " км/ч",
                        Image = GetImage(forecast.Text),
                    });
                }

                return newForecastViews;
        }

        private static BitmapImage GetImage(string imageName)
        {
            return new BitmapImage(new Uri("icons/" + imageName.ToLower() + ".png", UriKind.RelativeOrAbsolute));
        }
    }
}
