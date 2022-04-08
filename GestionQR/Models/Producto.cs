namespace GestionQR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Producto")]
    public partial class Producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Producto()
        {
            Quejas = new HashSet<Quejas>();
            Reclamaciones = new HashSet<Reclamaciones>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Tipo_Producto { get; set; }
        [Required(ErrorMessage = "Elige la fecha")]
        [DataType(DataType.Date)]
        public DateTime Fecha_Ortogamiento { get; set; }

        public int Estado_Producto { get; set; }

        public virtual Estado Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Quejas> Quejas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reclamaciones> Reclamaciones { get; set; }
    }
}
