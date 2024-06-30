namespace Lead_MS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class ROLES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ROLES()
        {
            USUARIOS = new HashSet<USUARIOS>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string NOMBRE { get; set; }

        [StringLength(255)]
        public string DESCRIPCION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USUARIOS> USUARIOS { get; set; }

        // METODO LISTAR
        public List<ROLES> Listar()
        {
            var roles = new List<ROLES>();
            try
            {
                using (var db = new ModeloLMS())
                {
                    roles = db.ROLES.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los roles", ex);
            }

            return roles;
        }

        // METODO OBTENER
        public ROLES Obtener(int id)
        {
            ROLES rol = null;
            try
            {
                using (var db = new ModeloLMS())
                {
                    rol = db.ROLES.SingleOrDefault(x => x.ID == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el rol", ex);
            }

            return rol;
        }

        // METODO GUARDAR
        public void Guardar()
        {
            try
            {
                using (var db = new ModeloLMS())
                {
                    if (this.ID > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        db.ROLES.Add(this);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar el rol", ex);
            }
        }

        // METODO ELIMINAR
        public void Eliminar()
        {
            try
            {
                using (var db = new ModeloLMS())
                {
                    db.Entry(this).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el rol", ex);
            }
        }
    }
}
