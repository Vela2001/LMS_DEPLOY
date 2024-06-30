namespace Lead_MS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GESTION_SMS_CAMPAÑA
    {
        [Key]
        public int ID_GESTION_SMS { get; set; }

        public int ID_CAMPAÑA { get; set; }

        [Required]
        [StringLength(50)]
        public string NUMERO_DESTINO { get; set; }

        [Required]
        [StringLength(50)]
        public string ESTADO_SMS { get; set; }

        public DateTime FECHA_ENVIO { get; set; }

        public virtual CAMPAÑAS CAMPAÑAS { get; set; }
    }
}
