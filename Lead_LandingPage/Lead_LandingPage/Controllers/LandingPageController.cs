using System;
using System.Web.Mvc;
using Lead_LandingPage.Models;

namespace Lead_LandingPage.Controllers
{
    public class LandingPageController : Controller
    {
        // GET: LandingPage
        public ActionResult Index()
        {
            ViewBag.RegistroExitoso = false; // Indicador de registro exitoso inicializado en falso
            return View(new ClsLeadsForm());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GuardarLP(ClsLeadsForm leadViewModel)
        {
            if (ModelState.IsValid)
            {
                // Mapear los datos del ViewModel al modelo LEADS
                var lead = new LEADS
                {
                    NOMBRE = leadViewModel.NOMBRE,
                    EMAIL = leadViewModel.EMAIL,
                    TELEFONO = leadViewModel.TELEFONO,
                    EMPRESA = leadViewModel.EMPRESA,
                    FECHA_CREACION = DateTime.Now, // Asignar la fecha de creación
                    CARGO = "Dev", // Valor por defecto
                    ESTADO = "Blizzard ENT.", // Valor por defecto
                    FUENTE_ENTRADA = "Landing Page" // Valor por defecto
                };

                lead.GuardarLP();
                ViewBag.RegistroExitoso = true; // Indicador de éxito
                return View("Index", new ClsLeadsForm()); // Crear un nuevo objeto LeadViewModel para resetear el formulario
            }

            ViewBag.RegistroExitoso = false; // Si el modelo no es válido, mantener el indicador en falso
            return View("Index", leadViewModel); // Volver a la vista "Index" con el modelo actual si no es válido
        }
    }
}