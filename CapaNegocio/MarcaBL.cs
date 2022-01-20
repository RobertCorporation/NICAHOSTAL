using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class MarcaBL
    {
        public List<MarcaCLS> ListarMarca()
        {
            MarcaDAL marcaDAL = new MarcaDAL();
            return marcaDAL.ListarMarcas();
        }

        public List<MarcaCLS> BuscarMarca(string nombre)
        {
            MarcaDAL marcaDAL = new MarcaDAL();
            return marcaDAL.BuscarPorNombre(nombre);
        }
    }
}
