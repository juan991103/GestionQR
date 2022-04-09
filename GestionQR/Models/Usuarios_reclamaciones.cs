namespace GestionQR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Usuarios_reclamaciones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuarios_reclamaciones()
        {
            Reclamaciones = new HashSet<Reclamaciones>();
            Reclamaciones1 = new HashSet<Reclamaciones>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Usuario_reclamo { get; set; }

        [Required]
        [StringLength(100)]
        public string Clave { get; set; }

        public int Departamento { get; set; }

        public int Rol { get; set; }

        public int Puesto { get; set; }

        public virtual Departamentos Departamentos { get; set; }

        public virtual Puesto Puesto1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reclamaciones> Reclamaciones { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reclamaciones> Reclamaciones1 { get; set; }

        public virtual Rol Rol1 { get; set; }
    }
}
