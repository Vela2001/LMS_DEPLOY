namespace Lead_LandingPage.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class INTERACCIONES
    {
        public int ID { get; set; }

        public int ID_LEAD { get; set; }

        [Required]
        [StringLength(50)]
        public string TIPO_INTERACCION { get; set; }

        [Column(TypeName = "text")]
        public string DETALLE { get; set; }

        public DateTime FECHA_INTERACCION { get; set; }

        public virtual LEADS LEADS { get; set; }
    }
}
