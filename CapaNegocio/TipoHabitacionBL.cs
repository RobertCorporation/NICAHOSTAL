using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class TipoHabitacionBL
    {
        public List<TipoHabitacionCLS> listarTipoHabitacion()
        {
            TipoHabitacionDAL otipoHabitacionDAL = new TipoHabitacionDAL();
            return otipoHabitacionDAL.listarTipoHabitacion();

        }
        
    }
}
