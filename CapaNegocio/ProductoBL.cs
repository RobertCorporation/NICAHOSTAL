using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ProductoBL
    {
        public List<ProductoCLS> Listarprod()
        {
            ProductoDAL oProductoDAL = new ProductoDAL();
            return oProductoDAL.Listar();
        }
        public List<ProductoCLS> BuscarProductos(string nombre)
        {
            ProductoDAL oProductoDAL = new ProductoDAL();
            return oProductoDAL.BuscarPorNombre(nombre);
        }
    }
}
