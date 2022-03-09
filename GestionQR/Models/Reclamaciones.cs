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
    
    public partial class Reclamaciones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reclamaciones()
        {
            this.Gestor_usuarios_reclamaciones = new HashSet<Gestor_usuarios_reclamaciones>();
            this.Gestor_usuarios_reclamaciones1 = new HashSet<Gestor_usuarios_reclamaciones>();
        }
    
        public int Id { get; set; }
        public int Nombre_Cliente { get; set; }
        public int Tipo_Reclamacion { get; set; }
        public int Tipo_Producto { get; set; }
        public int Departamento_a_Reclamacion { get; set; }
        public int Usuario_Reclamo_Atendido { get; set; }
        public System.DateTime Fecha_Reclamacion { get; set; }
        public System.DateTime Hora_Reclamacion { get; set; }
        public string Departamento_Respuesta { get; set; }
        public System.DateTime Fecha_Respuesta { get; set; }
        public int Estado_Reclamacion { get; set; }
        public string Comentarios_Reclamaciones { get; set; }
    
        public virtual Clientes Clientes { get; set; }
        public virtual Departamentos Departamentos { get; set; }
        public virtual Estado Estado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Gestor_usuarios_reclamaciones> Gestor_usuarios_reclamaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Gestor_usuarios_reclamaciones> Gestor_usuarios_reclamaciones1 { get; set; }
        public virtual Producto Producto { get; set; }
        public virtual Tipo_reclamacion Tipo_reclamacion1 { get; set; }
        public virtual Usuarios_reclamaciones Usuarios_reclamaciones { get; set; }
    }
}
