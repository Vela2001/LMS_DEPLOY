namespace Lead_LandingPage.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;

    public partial class LEADS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LEADS()
        {
            ASIGNACIONES_LEAD = new HashSet<ASIGNACIONES_LEAD>();
            AUDITORIA_LEADS = new HashSet<AUDITORIA_LEADS>();
            CITAS = new HashSet<CITAS>();
            INTERACCIONES = new HashSet<INTERACCIONES>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string NOMBRE { get; set; }

        [Required]
        [StringLength(255)]
        public string EMAIL { get; set; }

        [StringLength(50)]
        public string TELEFONO { get; set; }

        [StringLength(255)]
        public string EMPRESA { get; set; }

        [StringLength(255)]
        public string CARGO { get; set; }

        [Required]
        [StringLength(100)]
        public string FUENTE_ENTRADA { get; set; }

        public DateTime FECHA_CREACION { get; set; }

        [Required]
        [StringLength(50)]
        public string ESTADO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASIGNACIONES_LEAD> ASIGNACIONES_LEAD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AUDITORIA_LEADS> AUDITORIA_LEADS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CITAS> CITAS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INTERACCIONES> INTERACCIONES { get; set; }

        public void GuardarLP()
        {
            try
            {
                using (var db = new ModeloLMS())
                {
                    if (this.ID > 0) //por existe en la bd
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else //=0 no existe
                    //nuevo objeto agregar
                    {
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
