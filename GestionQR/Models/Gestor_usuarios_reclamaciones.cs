//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GestionQR.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Gestor_usuarios_reclamaciones
    {
        public int Id { get; set; }
        public int Usuario_reclamo_ { get; set; }
        public int Nombre_Cliente { get; set; }
        public int Departamento_Reclamacion { get; set; }
        public int Rol { get; set; }
        public int Puesto { get; set; }
        public int Estado { get; set; }
    
        public virtual Estado Estado1 { get; set; }
        public virtual Reclamaciones Reclamaciones { get; set; }
        public virtual Reclamaciones Reclamaciones1 { get; set; }
        public virtual Puesto Puesto1 { get; set; }
        public virtual Usuarios_reclamaciones Usuarios_reclamaciones { get; set; }
        public virtual Rol Rol1 { get; set; }
    }
}