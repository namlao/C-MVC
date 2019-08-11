using System.Web;
using System.Web.Mvc;

namespace MaiAnhNam_baihat
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
