namespace Lead_MS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CAMPAÑAS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CAMPAÑAS()
        {
            GESTION_CORREO_CAMPAÑA = new HashSet<GESTION_CORREO_CAMPAÑA>();
            GESTION_SMS_CAMPAÑA = new HashSet<GESTION_SMS_CAMPAÑA>();
        }

        [Key]
        public int ID_CAMPAÑA { get; set; }

        [Required]
        [StringLength(255)]
        public string NOMBRE_CAMPAÑA { get; set; }

        public DateTime FECHA_CREACION { get; set; }

        public int ID_PLANTILLA { get; set; }

        public bool ACTIVO { get; set; }

        public virtual PLANTILLAS PLANTILLAS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GESTION_CORREO_CAMPAÑA> GESTION_CORREO_CAMPAÑA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GESTION_SMS_CAMPAÑA> GESTION_SMS_CAMPAÑA { get; set; }
    }
}
