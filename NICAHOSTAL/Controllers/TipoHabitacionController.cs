using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NICAHOSTAL.Controllers
{
    public class TipoHabitacionController : Controller
    {
        // GET: TipoHabitacion
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult Inicio()
        {
            return View();
        }
        public ActionResult VistaPruebaInicio()
        {
            return View();
        }

        public JsonResult ListAll()
        {
            TipoHabitacionBL obj = new TipoHabitacionBL();
            return Json(obj.listarTipoHabitacion(), JsonRequestBehavior.AllowGet);
        }
    }
}