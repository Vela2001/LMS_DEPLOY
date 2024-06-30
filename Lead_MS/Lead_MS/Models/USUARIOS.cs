namespace Lead_MS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class USUARIOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USUARIOS()
        {
            ASIGNACIONES_LEAD = new HashSet<ASIGNACIONES_LEAD>();
            AUDITORIA_LEADS = new HashSet<AUDITORIA_LEADS>();
            CITAS = new HashSet<CITAS>();
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

        public int ROL_ID { get; set; }

        [StringLength(255)]
        public string AVATAR { get; set; }

        [StringLength(50)]
        public string TELEFONO { get; set; }

        [StringLength(255)]
        public string DESCRIPCION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASIGNACIONES_LEAD> ASIGNACIONES_LEAD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AUDITORIA_LEADS> AUDITORIA_LEADS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CITAS> CITAS { get; set; }

        public virtual ROLES ROLES { get; set; }

        //Implementacion de metodos

        // METODO LISTAR
        //public List<USUARIOS> Listar()
        //{
        //    var usuarios = new List<USUARIOS>();
        //    try
        //    {
        //        using (var db = new ModeloLMS())
        //        {
        //            usuarios = db.USUARIOS.ToList();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error al listar los usuarios", ex);
        //    }

        //    return usuarios;
        //}
        // METODO LISTAR CON ROLES
        public List<USUARIOS> Listar()
        {
            var usuarios = new List<USUARIOS>();
            try
            {
                using (var db = new ModeloLMS())
                {
                    usuarios = db.USUARIOS.Include(u => u.ROLES).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los usuarios con roles", ex);
            }

            return usuarios;
        }

        // METODO OBTENER
        public USUARIOS Obtener(int id)
        {
            USUARIOS usuario = null;
            try
            {
                using (var db = new ModeloLMS())
                {
                    usuario = db.USUARIOS.Include(u => u.ROLES).SingleOrDefault(x => x.ID == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el usuario", ex);
            }

            return usuario;
        }


        // METODO BUSCAR
        public List<USUARIOS> Buscar(string criterio)
        {
            var usuarios = new List<USUARIOS>();
            try
            {
                using (var db = new ModeloLMS())
                {
                    usuarios = db.USUARIOS
                        .Where(x => x.NOMBRE_USUARIO.Contains(criterio) || x.EMAIL.Contains(criterio))
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar usuarios", ex);
            }

            return usuarios;
        }
        // METODO BUSCAR CON ROLES
        public List<USUARIOS> BuscarConRoles(string criterio)
        {
            var usuarios = new List<USUARIOS>();
            try
            {
                using (var db = new ModeloLMS())
                {
                    usuarios = db.USUARIOS
                        .Include(u => u.ROLES)
                        .Where(x => x.NOMBRE_USUARIO.Contains(criterio) || x.EMAIL.Contains(criterio))
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar usuarios con roles", ex);
            }

            return usuarios;
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
                        db.USUARIOS.Add(this);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar el usuario", ex);
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
                throw new Exception("Error al eliminar el usuario", ex);
            }
        }

        // METODO VALIDAR LOGIN
        public ResponseModel ValidarLogin(string Usuario, string Password)
        {
            var rm = new ResponseModel();
            try
            {
                using (var db = new ModeloLMS())
                {
                    Password = HashHelper.MD5(Password);

                    var usuario = db.USUARIOS.Where(x => x.NOMBRE_USUARIO == Usuario)
                                             .Where(x => x.HASH_CONTRASEÑA == Password)
                        .SingleOrDefault();

                    if (usuario != null)
                    {
                        SessionHelper.AddUserToSession(usuario.ID.ToString());
                        rm.SetResponse(true);
                    }
                    else
                    {
                        rm.SetResponse(false, "Usuario o contraseña incorrectos");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al validar el login", ex);
            }

            return rm;
        }

        // METODO GUARDAR PERFIL
        //public ResponseModel GuardarPerfil(HttpPostedFileBase foto)
        //{
        //    var rm = new ResponseModel();
        //    try
        //    {
        //        using (var db = new ModeloLMS())
        //        {
        //            db.Configuration.ValidateOnSaveEnabled = false;
        //            var usuario = db.Entry(this);
        //            usuario.State = EntityState.Modified;

        //            if (foto != null)
        //            {
        //                string extension = Path.GetExtension(foto.FileName).ToLower();
        //                int size = 1024 * 1024 * 5;
        //                var filtro = new[] { ".jpg", ".png", ".jpeg", ".gif" };

        //                if (filtro.Contains(extension) && (foto.ContentLength <= size))
        //                {
        //                    string archivo = Path.GetFileName(foto.FileName);
        //                    foto.SaveAs(HttpContext.Current.Server.MapPath("~/Uploads/" + archivo));
        //                    this.AVATAR = archivo;
        //                }
        //            }
        //            else
        //            {
        //                usuario.Property(x => x.AVATAR).IsModified = false;
        //            }

        //            db.SaveChanges();
        //            rm.SetResponse(true);
        //        }
        //    }
        //    catch (DbEntityValidationException ex)
        //    {
        //        throw new Exception("Error de validación de entidad", ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error al guardar el perfil", ex);
        //    }

        //    return rm;
        //}
    }
}
