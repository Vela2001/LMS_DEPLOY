namespace Lead_MS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PLANTILLAS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PLANTILLAS()
        {
            CAMPAÑAS = new HashSet<CAMPAÑAS>();
        }

        [Key]
        public int ID_PLANTILLA { get; set; }

        [Required]
        [StringLength(255)]
        public string NOMBRE_PLANTILLA { get; set; }

        [Required]
        [StringLength(255)]
        public string CONTENIDO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CAMPAÑAS> CAMPAÑAS { get; set; }
    }
}
