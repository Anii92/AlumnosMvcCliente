using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace AlumnosMvcCliente.Autofac
{
    public static class AutofacConfiguration
    {
        public static IContainer Build(Assembly assembly)
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(assembly);

            // Register dependencies in filter attributes
            builder.RegisterFilterProvider();

            builder.RegisterModule(new WebServiceModule());

            return builder.Build();
        }
    }
}