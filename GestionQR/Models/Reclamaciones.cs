//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GestionQR.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reclamaciones
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public string Usuario_Reclamo { get; set; }
        public string Tipo_Reclamacion { get; set; }
        public string Departamento_Reclamacion { get; set; }
        public string Encargado_Reclamacion { get; set; }
        public System.DateTime Fecha_Reclamacion { get; set; }
        public System.DateTime Hora_Reclamacion { get; set; }
        public string Departamento_Respuesta { get; set; }
        public System.DateTime Fecha_Respuesta { get; set; }
        public bool Estatus_Reclamacion { get; set; }
        public string Comentarios_Reclamaciones { get; set; }
    }
}