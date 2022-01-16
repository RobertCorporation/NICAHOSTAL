using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CamaBL
    {
        public List<CamaCLS> listarCama()
        {
            CamaDAL oCama = new CamaDAL();
            return oCama.listarCama();

        }
    }
}
