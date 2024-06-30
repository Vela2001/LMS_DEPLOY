using Lead_MS.Filters;
using Lead_MS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lead_MS.Controllers
{
    [Autenticado]
    public class UsuariosController : Controller
    {
        private USUARIOS objUsuario = new USUARIOS();
        private ROLES objRol = new ROLES();

        // GET: Usuarios
        public ActionResult Index(string Buscar)
        {
            var usuarios = string.IsNullOrEmpty(Buscar)
                ? objUsuario.Listar()
                : objUsuario.BuscarConRoles(Buscar);

            return View(usuarios);
        }

        public ActionResult Visualizar(int id)
        {
            var usuario = objUsuario.Obtener(id);
            return View(usuario);
        }

        public ActionResult Buscar(string Buscar)
        {
            return View(
                string.IsNullOrEmpty(Buscar)
                ? objUsuario.Listar()
                : objUsuario.BuscarConRoles(Buscar)
            );
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.Roles = objRol.Listar();
            return View(id == 0 ? new USUARIOS() : objUsuario.Obtener(id));
        }

        [HttpPost]
        public ActionResult Guardar(USUARIOS usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.Guardar();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Roles = objRol.Listar();
                return View("AgregarEditar", usuario);
            }
        }

        public ActionResult Eliminar(int id)
        {
            objUsuario.ID = id;
            objUsuario.Eliminar();
            return RedirectToAction("Index");
        }
    }
}
