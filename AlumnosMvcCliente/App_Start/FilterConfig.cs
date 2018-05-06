using AlumnosMvcCliente.Filters;
using System.Web;
using System.Web.Mvc;

namespace AlumnosMvcCliente
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LocalizationAttribute("en-US"), 0);
        }
    }
}
