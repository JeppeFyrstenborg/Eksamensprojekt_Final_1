using System.Web;
using System.Web.Mvc;

namespace Eksamensprojekt_Final_1_WebAPI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
