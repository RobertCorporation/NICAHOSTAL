using CapaNegocio;
using System;
using System.Collections.Generic;
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
    }
}