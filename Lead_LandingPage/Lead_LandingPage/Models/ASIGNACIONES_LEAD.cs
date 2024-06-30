namespace Lead_LandingPage.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ASIGNACIONES_LEAD
    {
        public int ID { get; set; }

        public int ID_LEAD { get; set; }

        public int ID_USUARIO { get; set; }

        public DateTime FECHA_ASIGNACION { get; set; }

        public virtual LEADS LEADS { get; set; }

        public virtual USUARIOS USUARIOS { get; set; }
    }
}
