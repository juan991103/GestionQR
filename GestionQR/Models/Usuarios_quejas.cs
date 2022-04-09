namespace GestionQR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Usuarios_quejas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuarios_quejas()
        {
            Quejas = new HashSet<Quejas>();
            Quejas1 = new HashSet<Quejas>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Usuario_quejas { get; set; }

        [Required]
        [StringLength(100)]
        public string Clave { get; set; }

        public int Departamento { get; set; }

        public int Rol { get; set; }

        public int Puesto { get; set; }

        public virtual Departamentos Departamentos { get; set; }

        public virtual Puesto Puesto1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Quejas> Quejas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Quejas> Quejas1 { get; set; }

        public virtual Rol Rol1 { get; set; }
    }
}
