using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumnosMvcCliente.Loggers
{
    public interface ILogger
    {
        void Info(Object message);
        void Warn(Object message);
        void Debug(Object message);
        void Error(Object message);
        void Fatal(Object message);
    }
}
