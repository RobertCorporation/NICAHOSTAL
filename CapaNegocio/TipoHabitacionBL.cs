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

        public List<TipoHabitacionCLS> FiltrarTipoHabitacion( string nombreHabitacion)
        {
            TipoHabitacionDAL otipoHabitacionDAL = new TipoHabitacionDAL();
            return otipoHabitacionDAL.FiltrarTipoHabitacion(nombreHabitacion);

        }

        public int GuardarTipoHabitacion(TipoHabitacionCLS oTipoHabitacion)
        {
            TipoHabitacionDAL oTipoHabitacionDAL = new TipoHabitacionDAL();
            return oTipoHabitacionDAL.GuardarTipoHabitacion(oTipoHabitacion);
        }

        public TipoHabitacionCLS  BuscarPorId(int Id)
        {
            TipoHabitacionDAL oTipoHabitacionDAL = new TipoHabitacionDAL();
            return oTipoHabitacionDAL.BuscarPorId(Id);
        }


    }
}
