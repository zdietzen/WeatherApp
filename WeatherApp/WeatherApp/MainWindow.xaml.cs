using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
using WeatherApp.Classes;

namespace WeatherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       // should we add this?----> public static CurrentConditions currentconditions;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string zip = SearchBar.Text;


            using (WebClient webClient = new WebClient())
                

            {
                //Tells the Weather Underground API who's boss
                webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

                // Grabs json info from github and saves it to a string.
                string json = webClient.DownloadString("http://api.wunderground.com/api/a3bf043be8c7fc4a/geolookup/conditions/q/" + zip + ".json");

                //this converts the json info into usable information for us
                CurrentConditions currentConditions = new CurrentConditions();
                currentConditions = JsonConvert.DeserializeObject<CurrentConditions>(json);

                //This stores the information that was converted to strings
                string Weather = currentConditions.weather;
                string Elevation = currentConditions.elevation;
                string Longitude = currentConditions.lon;
                string Latitude = currentConditions.lat;
                string LocationState = currentConditions.state;
                string LocationCity = currentConditions.city;
                string Temperature = currentConditions.temperature_string;
                string FeelsLike = currentConditions.feelslike_string;
                string Wind = currentConditions.wind_string;
                string WindDirection = currentConditions.wind_dir;
                string Humidity = currentConditions.relative_humidity;
                string UV = currentConditions.UV;
                string Visibility = currentConditions.visibility_mi;
                string Percipitation = currentConditions.precip_today_string;

                // writes the information out to the console


            }
        }
    }

}
    

