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
    
    public partial class Usuarios_de_quejas
    {
        public int Id { get; set; }
        public long Usuario_quejas { get; set; }
        public int Clave { get; set; }
        public long Departamento_Queja { get; set; }
        public System.DateTime Fecha_Queja { get; set; }
        public System.DateTime Hora_Queja { get; set; }
        public string Rol { get; set; }
        public string Puesto { get; set; }
        public string Cliente { get; set; }
        public string Producto { get; set; }
        public bool Estado { get; set; }
    }
}
