namespace GestionQR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Quejas
    {
        public int Id { get; set; }

        public int Nombre_Cliente { get; set; }

        public int Tipo_Quejas { get; set; }

        public int Tipo_Producto { get; set; }

        public int Departamento_a_Queja { get; set; }

        public int Usuario_Quejas_Atendido { get; set; }
        [Required(ErrorMessage = "Elige la fecha")]
        [DataType(DataType.Date)]
        public DateTime Fecha_Queja { get; set; }
        [Required(ErrorMessage = "Elige la hora")]
        [DataType(DataType.Time)]
        public TimeSpan Hora_Queja { get; set; }

        [StringLength(150)]
        public string Departamento_Respuesta { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Fecha_Respuesta { get; set; }

        public int Estado_Quejas { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(200)]
        public string Comentarios_Queja { get; set; }

        public virtual Clientes Clientes { get; set; }

        public virtual Departamentos Departamentos { get; set; }

        public virtual Estado Estado { get; set; }

        public virtual Producto Producto { get; set; }

        public virtual Tipo_quejas Tipo_quejas1 { get; set; }

        public virtual Usuarios_quejas Usuarios_quejas { get; set; }

        public virtual Usuarios_quejas Usuarios_quejas1 { get; set; }
    }
}
