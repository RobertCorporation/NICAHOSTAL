using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NICAHOSTAL.Controllers
{
    public class CamaController : Controller
    {
        // GET: Cama
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarCama()
        {
            CamaBL oCamaBL = new CamaBL();
            return Json(oCamaBL.listarCama(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult FiltrarCamaPorNombre(string nombre)
        {
            CamaBL obj = new CamaBL();
            return Json(obj.FiltrarCamaPorNombre(nombre), JsonRequestBehavior.AllowGet);
        }

        public int GuardarCama(CamaCLS oCamaCLS)
        {
            CamaBL oCamaBL = new CamaBL();
            return oCamaBL.GuardarCama(oCamaCLS);
        }
        public int EliminarCama(int IdCama)
        {
            CamaBL ocama = new CamaBL();
            return ocama.EliminarCama(IdCama);
        }
        public JsonResult RecuperarCama(int IdCamita)
        {
            CamaBL oCamaBL = new CamaBL();
            return Json(oCamaBL.RecuperarCamaPorId(IdCamita), JsonRequestBehavior.AllowGet);
        }


    }
}