using CapaDatos;
using CapaEntidad;
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
        public JsonResult FiltrarTipoHabitacionPorNombre(string nombreHabitacion)
        {
            TipoHabitacionBL obj = new TipoHabitacionBL();
            return Json(obj.FiltrarTipoHabitacion(nombreHabitacion), JsonRequestBehavior.AllowGet);
        }

        public int GuardarDatos(TipoHabitacionCLS oTipoHabitacionCLS)
        {
            TipoHabitacionBL obj = new TipoHabitacionBL();
            return obj.GuardarTipoHabitacion(oTipoHabitacionCLS);
        }

        public JsonResult BuscarPorId(int Id)
        {
            TipoHabitacionBL oTipoHabitacionBL = new TipoHabitacionBL();
            return Json(oTipoHabitacionBL.BuscarPorId(Id), JsonRequestBehavior.AllowGet);
        }

        public int EliminarDatos(int Id)
        {
            TipoHabitacionBL obj = new TipoHabitacionBL();
            return obj.EliminarTipoHabitacion(Id);
        }
    }
}