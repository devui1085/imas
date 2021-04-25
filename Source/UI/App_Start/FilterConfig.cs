using System.Web.Mvc;
using IMAS.UI.Infrastructure.Filters.Authentication;

namespace IMAS.UI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AutoSignInAttribute());
        }
    }
}
