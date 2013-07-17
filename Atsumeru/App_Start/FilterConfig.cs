using System.Web;
using System.Web.Mvc;
using Atsumeru.Api.Filters;

namespace Atsumeru
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}