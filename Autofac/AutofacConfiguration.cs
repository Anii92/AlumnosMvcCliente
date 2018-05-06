using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Autofac
{
    public static class AutofacConfiguration
    {
        public static IContainer Build(Assembly assembly)
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(assembly);

            builder.RegisterModule(new WebServiceModule());

            return builder.Build();
        }
    }
}
