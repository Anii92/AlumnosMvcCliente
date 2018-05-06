using AlumnosMvcCliente.Loggers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;

namespace AlumnosMvcCliente.Utils
{
    public static class Configurations
    {
        private static ILogger logger = CreateInstanceClassLog(MethodBase.GetCurrentMethod().DeclaringType);

        #region ConfigurarLogger
        public static ILogger CreateInstanceClassLog(Type typeDeclaring)
        {
            try
            {
                var tipoLog = Environment.GetEnvironmentVariable("Logger", EnvironmentVariableTarget.User);
                var key = ReadValueFromWebConfig(tipoLog);

                Type t = Assembly.GetExecutingAssembly().GetType(key);

                object[] mParam = new object[] { typeDeclaring };
                return (ILogger)Activator.CreateInstance(t, mParam);
            }
            catch (ArgumentNullException exception)
            {
                throw;
            }
            catch (ArgumentException exception)
            {
                throw;
            }

        }
        #endregion

        public static string ReadValueFromWebConfig(string key)
        {
            try
            {
                return ConfigurationManager.AppSettings[key];
            }
            catch (ConfigurationErrorsException exception)
            {
                throw;
            }
        }
    }
}