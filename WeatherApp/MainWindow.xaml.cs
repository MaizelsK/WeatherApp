using System;
using System.Collections.Generic;
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

namespace WeatherApp
{
    public partial class MainWindow : Window
    {
        public string weatherApi;

        public MainWindow()
        {
            weatherApi = "07f873a032cff98db6a2498110f9a6a8";

            InitializeComponent();

            //WebClient client = new WebClient();
            //var data = client.DownloadString(new Uri("https://api.openweathermap.org/data/2.5/forecast?q=Astana,kz&mode=json&APIID=" + weatherApi));


            using (var context = new WeatherContext())
            {
                var cities = context.Cities.ToList();
            }
        }

        private void LoadBtnClick(object sender, RoutedEventArgs e)
        {
            WebClient client = new WebClient();

            client.DownloadStringAsync(new Uri("https://mail.ru"));
        }
    }
}
