using AlumnosMvcCliente.Loggers;
using AlumnosMvcCliente.Models;
using AlumnosMvcCliente.Resources;
using AlumnosMvcCliente.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AlumnosMvcCliente.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger logger = Configurations.CreateInstanceClassLog(MethodBase.GetCurrentMethod().DeclaringType);
        private WebService webService;

        public HomeController(WebService webService)
        {
            this.webService = webService;
        }

        public async Task<ActionResult> Index()
        {
            this.logger.Debug(ResourceLogger.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            var students = await this.GetStudents();
            this.logger.Debug(ResourceLogger.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            return View(students);
        }

        private async Task<List<Student>> GetStudents()
        {
            try
            {
                this.logger.Debug(ResourceLogger.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                var students = await this.CallWebServices<Student>(Configurations.ReadValueFromWebConfig("AllStudentsEndPoint"));
                this.logger.Debug(ResourceLogger.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return students;
            }
            catch (Exception exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }

        private async Task<List<T>> CallWebServices<T>(string endpoint)
        {
            this.logger.Debug(ResourceLogger.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            var students = await this.webService.ReadAsync<T>(endpoint);
            this.logger.Debug(ResourceLogger.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            return students;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}