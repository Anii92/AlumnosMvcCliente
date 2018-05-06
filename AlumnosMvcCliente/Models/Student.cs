using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlumnosMvcCliente.Models
{
    public class Student
    {
        #region Propiedades
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Dni { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public DateTime FechaHora { get; set; }
        #endregion
    }
}