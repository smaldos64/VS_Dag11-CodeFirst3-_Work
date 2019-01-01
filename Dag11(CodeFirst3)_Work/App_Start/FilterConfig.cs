using System.Web;
using System.Web.Mvc;

namespace Dag11_CodeFirst3__Work
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
