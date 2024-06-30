namespace Lead_MS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GESTION_CORREO_CAMPAÑA
    {
        [Key]
        public int ID_GESTION_CORREO { get; set; }

        public int ID_CAMPAÑA { get; set; }

        [Required]
        [StringLength(255)]
        public string CORREO_DESTINO { get; set; }

        [Required]
        [StringLength(50)]
        public string ESTADO_CORREO { get; set; }

        public DateTime FECHA_ENVIO { get; set; }

        public virtual CAMPAÑAS CAMPAÑAS { get; set; }
    }
}
