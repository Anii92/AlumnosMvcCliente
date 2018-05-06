using AlumnosMvcCliente.Loggers;
using AlumnosMvcCliente.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;

namespace AlumnosMvcCliente.Utils
{
    public class WebService
    {
        private readonly ILogger logger = Configurations.CreateInstanceClassLog(MethodBase.GetCurrentMethod().DeclaringType);
        public string BaseUrl { get; set; }

        public HttpClient Client { get; set; }

        public WebService(HttpClient httpClient)
        {
            this.logger.Debug(ResourceLogger.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            this.Client = httpClient;
            this.BaseUrl = Configurations.ReadValueFromWebConfig("BaseUrl");
            this.InitializeService();
            this.logger.Debug(ResourceLogger.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        private void InitializeService()
        {
            try
            {
                this.logger.Debug(ResourceLogger.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                this.Client.BaseAddress = new Uri(this.BaseUrl);
                this.Client.DefaultRequestHeaders.Accept.Clear();
                this.Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                this.logger.Debug(ResourceLogger.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (ArgumentNullException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
            catch (UriFormatException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }

        public async Task<List<T>> ReadAsync<T>(string endpoint)
        {
            try
            {
                this.logger.Debug(ResourceLogger.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                var response = await this.Client.GetAsync(endpoint);
                response.EnsureSuccessStatusCode();
                using (HttpContent content = response.Content)
                {
                    var rates = await response.Content.ReadAsAsync<List<T>>();
                    this.logger.Debug(ResourceLogger.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                    return rates;
                }
            }
            catch (ArgumentNullException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
            catch (HttpRequestException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }

        }
    }
}