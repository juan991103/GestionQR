namespace GestionQR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Reclamaciones
    {
        public int Id { get; set; }

        public int Nombre_Cliente { get; set; }

        public int Tipo_Reclamacion { get; set; }

        public int Tipo_Producto { get; set; }

        public int Departamento_a_Reclamacion { get; set; }

        public int Usuario_Reclamo_Atendido { get; set; }

        [Required(ErrorMessage = "Elige la fecha")]
        [DataType(DataType.Date)]
        public DateTime Fecha_Reclamacion { get; set; }
        [Required(ErrorMessage = "Elige la hora")]
        [DataType(DataType.Time)]
        public TimeSpan Hora_Reclamacion { get; set; }

        [StringLength(50)]
        public string Departamento_Respuesta { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Fecha_Respuesta { get; set; }

        public int Estado_Reclamacion { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(200)]
        public string Comentarios_Reclamaciones { get; set; }

        public virtual Clientes Clientes { get; set; }

        public virtual Departamentos Departamentos { get; set; }

        public virtual Estado Estado { get; set; }

        public virtual Producto Producto { get; set; }

        public virtual Tipo_reclamacion Tipo_reclamacion1 { get; set; }

        public virtual Usuarios_reclamaciones Usuarios_reclamaciones { get; set; }

        public virtual Usuarios_reclamaciones Usuarios_reclamaciones1 { get; set; }
    }
}
