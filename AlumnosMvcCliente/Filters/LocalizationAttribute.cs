using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace AlumnosMvcCliente.Filters
{
    public class LocalizationAttribute : ActionFilterAttribute
    {
        private string defaultLanguage = "es";

        public LocalizationAttribute(string defaultLanguage)
        {
            this.defaultLanguage = defaultLanguage;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string culture = (string)filterContext.RouteData.Values["culture"] ?? this.defaultLanguage;
            if (culture != this.defaultLanguage)
            {
                try
                {
                    Thread.CurrentThread.CurrentCulture =
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
                }
                catch (Exception e)
                {
                    throw new NotSupportedException(String.Format("ERROR: Invalid language code '{0}'.", culture));
                }
            }
        }
    }
}