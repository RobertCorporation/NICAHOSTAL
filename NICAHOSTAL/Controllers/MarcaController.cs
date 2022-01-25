using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NICAHOSTAL.Controllers
{
    public class MarcaController : Controller
    {
        // GET: Marca
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarMarca()
        {
            MarcaBL marcabl = new MarcaBL();
            return Json(marcabl.ListarMarca(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult BuscarMarca(string nombre)
        {
            MarcaBL marcalb = new MarcaBL();
            return Json(marcalb.BuscarMarca(nombre), JsonRequestBehavior.AllowGet);
        }

        public JsonResult BuscarPorId(int Id)
        {
            MarcaBL oMarcaBL = new MarcaBL();
            return Json(oMarcaBL.BuscarMarcaPorId(Id), JsonRequestBehavior.AllowGet);
        }
        public int GuardarDatos(MarcaCLS oMarcaCLS)
        {
            MarcaBL obj = new MarcaBL();
            return obj.GuardarMarca(oMarcaCLS);
        }

        public int EliminarDatos(int Id)
        {
            MarcaBL obj = new MarcaBL();
            return obj.EliminarMarca(Id);
        }
    }
}