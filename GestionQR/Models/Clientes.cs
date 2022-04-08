namespace GestionQR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Clientes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Clientes()
        {
            EncuestaSatisfaccion1 = new HashSet<EncuestaSatisfaccion1>();
            Quejas = new HashSet<Quejas>();
            Reclamaciones = new HashSet<Reclamaciones>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(50)]
        public string Nombres_Cliente { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(50)]
        public string Apellidos_Cliente { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(45)]
        public string Teléfono { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(50)]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(50)]
        public string Provincia { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(50)]
        public string Sector { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(50)]
        public string Email { get; set; }

        public int Estado { get; set; }

        public virtual Estado Estado1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EncuestaSatisfaccion1> EncuestaSatisfaccion1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Quejas> Quejas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reclamaciones> Reclamaciones { get; set; }
    }
}
