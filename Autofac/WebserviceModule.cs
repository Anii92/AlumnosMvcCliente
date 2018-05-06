using AlumnosMvcCliente.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Autofac
{
    public class WebServiceModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<HttpClient>();

            base.Load(builder);
        }
    }
}
