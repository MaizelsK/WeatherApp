using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WeatherApp.OpenWeatherAPI;
using WeatherApp.YahooAPI;

namespace WeatherApp
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<ForecastView> forecastItems;

        public MainWindow()
        {
            InitializeComponent();

            forecastItems = new ObservableCollection<ForecastView>();
            weatherList.ItemsSource = forecastItems;
        }

        private async void LoadBtnClick(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TextBox.Text))
            {
                MessageBox.Show("Введите название города!");
                return;
            }

            Example forecasts = await WeatherData.GetForecastData(TextBox.Text);

            if (forecasts.Query.Results != null)
                weatherList.ItemsSource = WeatherData.GetForecastList(forecasts);
        }

        private void InitializeDatabase()
        {
            FileInfo info = new FileInfo("city.list.json");
            var data = info.OpenText().ReadToEnd();

            List<City> cities = JsonConvert.DeserializeObject<List<City>>(data);

            using (var context = new WeatherContext())
            {
                int border = 0;

                for (int i = 0; i < cities.Count; i++)
                {
                    context.Cities.Add(cities[i]);
                    border++;

                    if (border == 1000)
                    {
                        border = 0;
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
