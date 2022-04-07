namespace GestionQR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EncuestaSatisfaccion1
    {
        public int Id { get; set; }

        public int Pregunta1 { get; set; }

        public int Pregunta2 { get; set; }

        public int Pregunta3 { get; set; }

        public int Pregunta4 { get; set; }

        public int Pregunta5 { get; set; }

        public int Pregunta6 { get; set; }

        public int Cliente { get; set; }

        public virtual Clientes Clientes { get; set; }

        public virtual Estado2 Estado2 { get; set; }

        public virtual Estado2 Estado21 { get; set; }

        public virtual Estado2 Estado22 { get; set; }

        public virtual Estado2 Estado23 { get; set; }

        public virtual Estado2 Estado24 { get; set; }

        public virtual Estado2 Estado25 { get; set; }
    }
}
