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
using WeatherApp.YahooAPI;

namespace WeatherApp
{
    public partial class MainWindow : Window
    {
        private bool isLoading;

        public MainWindow()
        {
            InitializeComponent();

            isLoading = false;
        }

        // Загрузка прогноза
        private async void LoadBtnClick(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TextBox.Text))
            {
                MessageBox.Show("Enter the city name");
                return;
            }

            ChangeLoadingVisibility();

            Example forecasts = await WeatherData.GetForecastData(TextBox.Text);

            if (forecasts.Query.Results != null)
                weatherList.ItemsSource = WeatherData.GetForecastList(forecasts);
            else
                MessageBox.Show("No data for entered city...");

            ChangeLoadingVisibility();
        }

        // Смена видимости загрузки
        private void ChangeLoadingVisibility()
        {
            if (isLoading)
            {
                isLoading = false;

                LoadingGif.Visibility = Visibility.Hidden;
                LoadingRect.Visibility = Visibility.Hidden;
            }
            else
            {
                isLoading = true;

                LoadingGif.Visibility = Visibility.Visible;
                LoadingRect.Visibility = Visibility.Visible;
            }
        }
    }
}
