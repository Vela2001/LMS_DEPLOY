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
        [NoLogin]
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
    }
}