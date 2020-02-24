using System.Web;
using System.Web.Mvc;

namespace MyFavoritesWeather
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
