﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AlumnosMvcCliente.App_GlobalResources {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o recompile su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("AlumnosMvcCliente.App_GlobalResources.Resource", typeof(Resource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Edad.
        /// </summary>
        public static string age {
            get {
                return ResourceManager.GetString("age", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Dni.
        /// </summary>
        public static string dni {
            get {
                return ResourceManager.GetString("dni", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a ID.
        /// </summary>
        public static string id {
            get {
                return ResourceManager.GetString("id", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Nombre.
        /// </summary>
        public static string name {
            get {
                return ResourceManager.GetString("name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Fecha de registro.
        /// </summary>
        public static string registrationDate {
            get {
                return ResourceManager.GetString("registrationDate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Seleccionar.
        /// </summary>
        public static string select {
            get {
                return ResourceManager.GetString("select", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Listado de alumnos.
        /// </summary>
        public static string studentList {
            get {
                return ResourceManager.GetString("studentList", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Apellidos.
        /// </summary>
        public static string surname {
            get {
                return ResourceManager.GetString("surname", resourceCulture);
            }
        }
    }
}