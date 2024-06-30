using Lead_MS.Filters;
using Lead_MS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lead_MS.Controllers
{
    [Autenticado]
    public class RolesController : Controller
    {
        private ROLES objRol = new ROLES();

        // GET: Roles
        public ActionResult Index()
        {
            return View(objRol.Listar());
        }

        public ActionResult Visualizar(int id)
        {
            // Asegúrate de tener el using necesario para .Include
            using (var dbContext = new ModeloLMS())
            {
                // Reemplaza esta consulta con la que incluye ROLES
                var usuario = dbContext.USUARIOS.Include(u => u.ROLES).FirstOrDefault(u => u.ID == id);

                if (usuario == null)
                {
                    // Maneja el caso en que el usuario no se encuentre
                    return HttpNotFound();
                }

                return View(usuario);
            }
        }


        public ActionResult AgregarEditar(int id = 0)
        {
            return View(id == 0 ? new ROLES() : objRol.Obtener(id));
        }

        [HttpPost]
        public ActionResult Guardar(ROLES rol)
        {
            if (ModelState.IsValid)
            {
                rol.Guardar();
                return RedirectToAction("Index");
            }
            else
            {
                return View("AgregarEditar", rol);
            }
        }

        public ActionResult Eliminar(int id)
        {
            objRol.ID = id;
            objRol.Eliminar();
            return RedirectToAction("Index");
        }
    }
}