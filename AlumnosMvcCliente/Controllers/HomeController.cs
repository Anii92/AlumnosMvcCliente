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

        public async Task<ActionResult> Delete(int id)
        {
            this.logger.Debug(ResourceLogger.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            await this.DeleteStudent(id);
            this.logger.Debug(ResourceLogger.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);

            return RedirectToAction("Index", "Home");
        }

        private async Task DeleteStudent(int id)
        {
            this.logger.Debug(ResourceLogger.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            string endpoint = Configurations.ReadValueFromWebConfig("DeleteByIdEndpoint") + "/" + id;
            await this.CallDeleteWebServices<int>(endpoint);
            this.logger.Debug(ResourceLogger.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        public async Task<ActionResult> Details(int id)
        {
            this.logger.Debug(ResourceLogger.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            string endpoint = Configurations.ReadValueFromWebConfig("StudentByIdEndpoint") + "/" + id;
            var student = await this.CallReadWebServices<Student>(endpoint);
            this.logger.Debug(ResourceLogger.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            return View(student);
        }

        public async Task<ActionResult> Edit(int id)
        {
            this.logger.Debug(ResourceLogger.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            string endpoint = Configurations.ReadValueFromWebConfig("StudentByIdEndpoint") + "/" + id;
            var student = await this.CallReadWebServices<Student>(endpoint);
            this.logger.Debug(ResourceLogger.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            return View(student);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Student student)
        {
            this.logger.Debug(ResourceLogger.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            string endpoint = Configurations.ReadValueFromWebConfig("UpdateStudentEndpoint");
            await this.CallPostWebServices<Student>(endpoint, student);
            this.logger.Debug(ResourceLogger.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Create()
        {
            this.logger.Debug(ResourceLogger.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            this.logger.Debug(ResourceLogger.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Student student)
        {
            this.logger.Debug(ResourceLogger.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            string endpoint = Configurations.ReadValueFromWebConfig("CreateStudentEndpoint");
            await this.CallPostWebServices<Student>(endpoint, student);
            this.logger.Debug(ResourceLogger.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            return RedirectToAction("Index");
        }

        private async Task<List<Student>> GetStudents()
        {
            try
            {
                this.logger.Debug(ResourceLogger.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                var students = await this.CallReadAllWebServices<Student>(Configurations.ReadValueFromWebConfig("AllStudentsEndPoint"));
                this.logger.Debug(ResourceLogger.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return students;
            }
            catch (Exception exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }

        private async Task<List<T>> CallReadAllWebServices<T>(string endpoint)
        {
            this.logger.Debug(ResourceLogger.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            var results = await this.webService.ReadAllAsync<T>(endpoint);
            this.logger.Debug(ResourceLogger.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            return results;
        }

        private async Task<T> CallReadWebServices<T>(string endpoint)
        {
            this.logger.Debug(ResourceLogger.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            var result = await this.webService.ReadAsync<T>(endpoint);
            this.logger.Debug(ResourceLogger.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            return result;
        }

        private async Task<T> CallDeleteWebServices<T>(string endpoint)
        {
            this.logger.Debug(ResourceLogger.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            var result = await this.webService.DeleteAsync<T>(endpoint);
            this.logger.Debug(ResourceLogger.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            return result;
        }

        private async Task<T> CallPostWebServices<T>(string endpoint, T data)
        {
            this.logger.Debug(ResourceLogger.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            var result = await this.webService.UpdateAsync<T>(endpoint, data);
            this.logger.Debug(ResourceLogger.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            return result;
        }
    }
}