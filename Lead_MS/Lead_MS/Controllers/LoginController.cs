using Lead_MS.Filters;
using Lead_MS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lead_MS.Controllers
{
    public class LoginController : Controller
    {
        private USUARIOS usuario = new USUARIOS();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Validar(string Usuario, string Password)
        {
            var rm = usuario.ValidarLogin(Usuario, Password);
            if (rm.response)
            {
                rm.href = Url.Content("~/Default");
            }
            return Json(rm);
        }

        public ActionResult Logout()
        {
            SessionHelper.DestroyUserSession();
            return Redirect("~/Login");
        }

        [HttpGet]
        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(USUARIOS model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (var db = new ModeloLMS())
                    {
                        if (db.USUARIOS.Any(u => u.NOMBRE_USUARIO == model.NOMBRE_USUARIO || u.EMAIL == model.EMAIL))
                        {
                            return Json(new { success = false, message = "El nombre de usuario o email ya está en uso." });
                        }

                        model.HASH_CONTRASEÑA = HashHelper.MD5(model.HASH_CONTRASEÑA);
                        model.ROL_ID = 2; // Asumiendo que 2 es el ID para usuarios normales

                        db.USUARIOS.Add(model);
                        db.SaveChanges();

                        return Json(new { success = true, message = "Registro exitoso." });
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = "Ocurrió un error al registrar el usuario: " + ex.Message });
                }
            }

            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            return Json(new { success = false, message = "Por favor, corrija los errores en el formulario.", errors = errors });
        }
    }
}