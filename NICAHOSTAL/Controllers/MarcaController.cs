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
    }
}