using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AlumnosMvcCliente
{
    public class LocalizedControllerActivator : IControllerActivator
    {
        private string defaultLanguage = "es";

        public IController Create(RequestContext requestContext, Type controllerType)
        {
            //Get the {language} parameter in the RouteData
            string culture = (string) requestContext.RouteData.Values["culture"] ?? this.defaultLanguage;

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

            return DependencyResolver.Current.GetService(controllerType) as IController;
        }
    }
}