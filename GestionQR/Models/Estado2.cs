namespace GestionQR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Estado2
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Estado2()
        {
            EncuestaSatisfaccion1 = new HashSet<EncuestaSatisfaccion1>();
            EncuestaSatisfaccion11 = new HashSet<EncuestaSatisfaccion1>();
            EncuestaSatisfaccion12 = new HashSet<EncuestaSatisfaccion1>();
            EncuestaSatisfaccion13 = new HashSet<EncuestaSatisfaccion1>();
            EncuestaSatisfaccion14 = new HashSet<EncuestaSatisfaccion1>();
            EncuestaSatisfaccion15 = new HashSet<EncuestaSatisfaccion1>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EncuestaSatisfaccion1> EncuestaSatisfaccion1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EncuestaSatisfaccion1> EncuestaSatisfaccion11 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EncuestaSatisfaccion1> EncuestaSatisfaccion12 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EncuestaSatisfaccion1> EncuestaSatisfaccion13 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EncuestaSatisfaccion1> EncuestaSatisfaccion14 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EncuestaSatisfaccion1> EncuestaSatisfaccion15 { get; set; }
    }
}
