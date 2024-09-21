using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lead_MS.Filters;
using Lead_MS.Models;

namespace Lead_MS.Controllers
{
    //[Autenticado]
    public class LeadsController : Controller
    {
        private LEADS objLead = new LEADS();

        // GET: LEADS
        public ActionResult Index(string Buscar)
        {
            if (string.IsNullOrEmpty(Buscar))
            {
                return View(objLead.Listar());
            }
            else
            {
                return View(objLead.Buscar(Buscar));
            }
        }

        public ActionResult Visualizar(int id)
        {
            return View(objLead.Obtener(id));
        }

        public ActionResult Buscar(string Buscar)
        {
            return View(
                string.IsNullOrEmpty(Buscar)
                ? objLead.Listar()
                : objLead.Buscar(Buscar)
            );
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            return View(id == 0 ? new LEADS() : objLead.Obtener(id));
        }

        [HttpPost]
        public ActionResult Guardar(LEADS lead)
        {
            if (ModelState.IsValid)
            {
                if (lead.ID == 0)
                {
                    lead.FECHA_CREACION = DateTime.Now; // Solo asignar si es un nuevo lead
                }
                lead.Guardar();
                return RedirectToAction("Index");
            }
            else
            {
                return View("AgregarEditar", lead);
            }
        }

        public ActionResult Eliminar(int id)
        {
            objLead.ID = id;
            objLead.Eliminar();
            return RedirectToAction("Index");
        }
    }
}