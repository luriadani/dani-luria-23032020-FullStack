using MyFavoritesWeather.BL;
using MyFavoritesWeather.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MyFavoritesWeather.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class WeatherController : ApiController
    {

        [HttpGet]
        [EnableCors("*", "*", "*")]
        [ActionName("Search")]
        public IEnumerable<City> Search(string term)
        {
            var result = WeatherFavoritesManager.Instance.SearchCity(term);
            return result;
            //return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [EnableCors("*", "*", "*")]
        public WeatherDetails GetCurrentWeather(string cityKey)
        {
            return WeatherFavoritesManager.Instance.GetCurrentWeather(cityKey);

        }

        [HttpPut]
        [EnableCors("*", "*", "*")]
        [ActionName("AddToFavorites")]
        public void AddToFavorites([FromBody]City cityData)
        {
            WeatherFavoritesManager.Instance.AddToFavorites(cityData);
        }
        [HttpPost]
        [EnableCors("*", "*", "*")]
        [ActionName("RemoveFromFavorites")]
        public void RemoveFromFavorites([FromBody]string cityId)
        {
            WeatherFavoritesManager.Instance.RemoveFromFavorites(cityId);
        }

        [HttpGet]
        [EnableCors("*", "*", "*")]
        [ActionName("getFavoritesCities")]
        public List<City> GetFavoritesCities()
        {
            return WeatherFavoritesManager.Instance.GetAllFavorites();           
        }

    }
}
