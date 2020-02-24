using MyFavoritesWeather.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MyFavoritesWeather.BL
{
    public class AccuWeatherServiceManager
    {
        #region singleton
        private static AccuWeatherServiceManager _instance = null;
        private static object obj = new object();
        public static AccuWeatherServiceManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (obj)
                    {
                        if (_instance == null)
                            _instance = new AccuWeatherServiceManager();
                    }
                }
                return _instance;
            }
        }

        private AccuWeatherServiceManager()
        {

        }
        #endregion

        string autoCompleteUrl = "http://dataservice.accuweather.com/locations/v1/cities/autocomplete";
        string getCurrentWeatherUrl = "http://dataservice.accuweather.com/currentconditions/v1/";
        string apikey = "ypT3Jv6FMxZqiXZtwiIP0ERwoxVN7cJC";
        public List<City> SearchCities(string searhcTerm)
        {
            if (String.IsNullOrEmpty(searhcTerm))
                return null;
           // return LoadMockupData();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(autoCompleteUrl);
                //HTTP GET
                var urlParams = String.Format("?apikey={0}&q={1}",apikey, searhcTerm);
                var responseTask = client.GetAsync(autoCompleteUrl+ urlParams);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<City[]>();
                    readTask.Wait();

                    var cities = readTask.Result;

                    return cities.ToList();
                }
            }
            return null;
        }

        private List<City> LoadMockupData()
        {
            var filePath = @"C:\Users\Dani\source\repos\MyFavoritesWeather\MyFavoritesWeather\SampleData\sampleData.json";
            //List<City> cities = new List<City>();
            JObject o1 = JObject.Parse(File.ReadAllText(filePath));

            JArray a = (JArray)o1["cities"];
            List<City> cities = a.ToObject<List<City>>();
            return cities;
        }

        public WeatherDetails GetCurrentWeather(string cityKey)
        {         
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(getCurrentWeatherUrl);
                //HTTP GET
                var urlParams = String.Format(@"/{0}?apikey={1}",cityKey, apikey);
                var responseTask = client.GetAsync(getCurrentWeatherUrl + urlParams);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<WeatherDetails[]>();
                    readTask.Wait();

                    var weatherData = readTask.Result;
                    if(weatherData.Count()>0)
                        return weatherData.ToList().First();
                }
            }
            return null;
        }

    }
}