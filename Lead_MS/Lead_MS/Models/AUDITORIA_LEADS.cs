namespace Lead_MS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AUDITORIA_LEADS
    {
        public int ID { get; set; }

        public int ID_LEAD { get; set; }

        [Required]
        [StringLength(50)]
        public string CAMPO_MODIFICADO { get; set; }

        [StringLength(255)]
        public string VALOR_ANTERIOR { get; set; }

        [StringLength(255)]
        public string VALOR_NUEVO { get; set; }

        public DateTime FECHA_MODIFICACION { get; set; }

        public int? USUARIO_MODIFICACION { get; set; }

        public virtual LEADS LEADS { get; set; }

        public virtual USUARIOS USUARIOS { get; set; }
    }
}
