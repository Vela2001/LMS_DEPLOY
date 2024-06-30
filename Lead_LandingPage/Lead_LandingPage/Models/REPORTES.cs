namespace Lead_LandingPage.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class REPORTES
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string TIPO_REPORTE { get; set; }

        public DateTime FECHA_GENERACION { get; set; }

        [Column(TypeName = "text")]
        public string CONTENIDO { get; set; }
    }
}
