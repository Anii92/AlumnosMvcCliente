using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlumnosMvcCliente.Loggers
{
    public class Log4NetAdapter : ILogger
    {
        private readonly ILog logger;

        public Log4NetAdapter(Type typeDeclaring)
        {
            this.logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        public void Debug(object message)
        {
            this.logger.Debug(message.ToString());
        }

        public void Error(object message)
        {
            this.logger.Error(message.ToString());
        }

        public void Fatal(object message)
        {
            this.logger.Fatal(message.ToString());
        }

        public void Info(object message)
        {
            this.logger.Info(message.ToString());
        }

        public void Warn(object message)
        {
            this.logger.Warn(message.ToString());
        }
    }
}