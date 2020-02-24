using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFavoritesWeather.Models
{
    public class WeatherDetails
    {        
        public DateTime LocalObservationDateTime { get; set; }
        public int EpochTime { get; set; }
        public string WeatherText { get; set; }
        public int WeatherIcon { get; set; }
        public bool HasPrecipitation { get; set; }
        public string PrecipitationType { get; set; }
        public bool IsDayTime { get; set; }
        public Temperature Temperature { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }
    }

    public class Temperature
    {
        public TempratureDetails Metric { get; set; }
        public TempratureDetails Imperial { get; set; }
    }
    public class TempratureDetails
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }
}