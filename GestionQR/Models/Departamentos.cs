namespace GestionQR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Departamentos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Departamentos()
        {
            Quejas = new HashSet<Quejas>();
            Reclamaciones = new HashSet<Reclamaciones>();
            Usuarios_quejas = new HashSet<Usuarios_quejas>();
            Usuarios_reclamaciones = new HashSet<Usuarios_reclamaciones>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre_departamento { get; set; }

        public long tipo_departamento { get; set; }

        public int Estado_Departamento { get; set; }

        public virtual Estado Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Quejas> Quejas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reclamaciones> Reclamaciones { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuarios_quejas> Usuarios_quejas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuarios_reclamaciones> Usuarios_reclamaciones { get; set; }
    }
}
