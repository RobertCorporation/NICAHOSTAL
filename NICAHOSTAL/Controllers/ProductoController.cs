using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NICAHOSTAL.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarProducto()
        {
            ProductoBL obj = new ProductoBL();
            return Json(obj.Listarprod(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult BuscarProducto(string nombre)
        {
            ProductoBL obj = new ProductoBL();
            return Json(obj.BuscarProductos(nombre), JsonRequestBehavior.AllowGet);
        }
    }
}