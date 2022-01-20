using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ProductoCLS
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string  NombreMarca { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal Stock { get; set; }
        public string  Denominacion { get; set; }
    }
}
