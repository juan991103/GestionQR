namespace GestionQR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tipo_reclamacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tipo_reclamacion()
        {
            Reclamaciones = new HashSet<Reclamaciones>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Descripción { get; set; }

        public int Estado { get; set; }

        public virtual Estado Estado1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reclamaciones> Reclamaciones { get; set; }
    }
}
