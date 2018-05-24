using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace WeatherApp
{
    public class WeatherContext : DbContext
    {
        public WeatherContext() : base("WeatherDb")
        {
            Database.SetInitializer(new WeatherDbInitializer());
        }
        
        public DbSet<Forecast> Forecasts { get; set; }
        public DbSet<Temperature> Temperatures { get; set; }
        public DbSet<Weather> Weather { get; set; }
        public DbSet<Coordinates> Coordinates { get; set; }
        public DbSet<City> Cities { get; set; }
    }

    public class WeatherDbInitializer : DropCreateDatabaseAlways<WeatherContext>
    {
        protected override void Seed(WeatherContext context)
        {
            //FileInfo info = new FileInfo("city.list.json");
            //var data = info.OpenText().ReadToEnd();

            //List<City> cities = JsonConvert.DeserializeObject<List<City>>(data);
            //context.Cities.AddRange(cities.Take(50000));

            base.Seed(context);
        }
    }
}
