namespace Lead_LandingPage.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class USUARIOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USUARIOS()
        {
            ASIGNACIONES_LEAD = new HashSet<ASIGNACIONES_LEAD>();
            AUDITORIA_LEADS = new HashSet<AUDITORIA_LEADS>();
            CITAS = new HashSet<CITAS>();
            ROLES = new HashSet<ROLES>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string NOMBRE_USUARIO { get; set; }

        [Required]
        [StringLength(255)]
        public string HASH_CONTRASEÑA { get; set; }

        [Required]
        [StringLength(255)]
        public string EMAIL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASIGNACIONES_LEAD> ASIGNACIONES_LEAD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AUDITORIA_LEADS> AUDITORIA_LEADS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CITAS> CITAS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ROLES> ROLES { get; set; }
    }
}
