using AlumnosMvcCliente.Utils;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace AlumnosMvcCliente.Autofac
{
    public class WebServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<HttpClient>();

            builder
                .RegisterType<WebService>();

            base.Load(builder);
        }
    }
}