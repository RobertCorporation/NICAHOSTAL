using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CapaDatos
{
    public class CadenaDAL
    {
        public string Cadena { get; set; }

        public CadenaDAL()
        {
            Cadena = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
        }
    }
}
