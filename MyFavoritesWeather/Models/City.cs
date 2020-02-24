using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFavoritesWeather.Models
{
    public class City
    {
        public int Version { get; set; }
        public string Key { get; set; }
        public string Type { get; set; }
        public int Rank { get; set; }
        public string LocalizedName { get; set; }
        public ExtraDetails Country { get; set; }
        public ExtraDetails AdministrativeArea { get; set; }
    }

    public class ExtraDetails
    {
        public string ID { get; set; }
        public string LocalizedName { get; set; }
    }

}