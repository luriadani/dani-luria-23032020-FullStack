using MyFavoritesWeather.DAL;
using MyFavoritesWeather.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace MyFavoritesWeather.BL
{
    public class WeatherFavoritesManager
    {
        #region singleton
        private static WeatherFavoritesManager _instance = null;
        private static object obj = new object();
        public static WeatherFavoritesManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (obj)
                    {
                        if (_instance == null)
                            _instance = new WeatherFavoritesManager();
                    }
                }
                return _instance;
            }
        }

        private WeatherFavoritesManager()
        {

        }
        #endregion

        internal WeatherDetails GetCurrentWeather(string cityKey)
        {
            var updateFavorites = false;
            using (var ctx = new MyFavoritesWeatherEntities())
            {
                if (ctx.FavoritesCities.Where(x => x.CityKey == cityKey).Any())
                {
                    var city = ctx.FavoritesCities.Where(x => x.CityKey == cityKey).First();
                    if (city != null)
                    {
                        updateFavorites = true;
                        if (city.CelsiusTemprature != null && !String.IsNullOrEmpty(city.WeatherText))
                            return (ConvertDalCityToWeatherDetails(city));
                    }
                }
                return (CallWeatherFromAccuWeather(cityKey, updateFavorites));
               
            }
        }

        private WeatherInfo ConvertDetailsToInfo(WeatherDetails wd)
        {
            return new WeatherInfo()
            {
                Temprature = wd.Temperature.Metric.Value,
                WeatherText = wd.WeatherText
            };
        }
        private WeatherDetails ConvertDalCityToWeatherDetails(FavoritesCity city)
        {
            WeatherDetails wd = new WeatherDetails();
            wd.Temperature = new Temperature();
            wd.Temperature.Metric = new TempratureDetails();
            wd.Temperature.Metric.Value = (double)city.CelsiusTemprature;
            wd.WeatherText = city.WeatherText;
            return wd;
        }

        private WeatherDetails CallWeatherFromAccuWeather(string cityKey, bool updateFavorites)
        {
            var wd = AccuWeatherServiceManager.Instance.GetCurrentWeather(cityKey);
            if (updateFavorites)
                UpdateFavorites(cityKey, wd);
            return wd;
        }

        private City ConvertFromWeatherDetailsToCity(string cityKey, WeatherDetails wd)
        {
            return new City()
            {
                Key = cityKey,

            };
        }

        private void UpdateFavorites(string cityKey, WeatherDetails wd)
        {
            using (var ctx = new MyFavoritesWeatherEntities())
            {
                var city = ctx.FavoritesCities.Where(x => x.CityKey == cityKey).First();
                if (city != null)
                {
                    city.CelsiusTemprature = wd.Temperature.Metric.Value;
                    city.WeatherText = wd.WeatherText;
                }
                ctx.SaveChanges();
            };
        }

        internal void AddToFavorites(City cityData)
        {
            using (var ctx = new MyFavoritesWeatherEntities())
            {
                if (!ctx.FavoritesCities.Where(x => x.CityKey == cityData.Key).Any())
                {
                    var item = new FavoritesCity()
                    {
                        CityKey = cityData.Key,
                        Name = cityData.LocalizedName,
                        Status = (int)Enums.FavoriteStatus.Active
                    };

                    ctx.FavoritesCities.Add(item);
                    ctx.SaveChanges();
                }
            };
        }

        internal void RemoveFromFavorites(string cityKey)
        {
            using (var ctx = new MyFavoritesWeatherEntities())
            {
                var item = ctx.FavoritesCities.Where(x => x.CityKey.Equals(cityKey)).First();
                if (item != null)
                {
                    ctx.FavoritesCities.Remove(item);
                    ctx.SaveChanges();
                }
            }
        }

        internal List<City> SearchCity(string term)
        {
            return AccuWeatherServiceManager.Instance.SearchCities(term);
        }

        internal City ConvertDalCityToObjCity(FavoritesCity dalCity)
        {
            return new City()
            {
                Key = dalCity.CityKey,
                LocalizedName = dalCity.Name,
            };
        }
        public List<City> GetAllFavorites()
        {
            using (var ctx = new MyFavoritesWeatherEntities())
            {
                var dbCities = from x in ctx.FavoritesCities select x;
                if (dbCities != null && dbCities.Count() > 0)
                {
                    var cities = new List<City>();
                    foreach (var city in dbCities)
                    {
                        cities.Add(ConvertDalCityToObjCity(city));
                    }
                    return cities;
                }
            }
            return null;
        }
    }
}