using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class TipoHabitacionDAL
    {
        public List<TipoHabitacionCLS> listarTipoHabitacion()
        {
            List<TipoHabitacionCLS> lista = new List<TipoHabitacionCLS>();
            lista.Add(new TipoHabitacionCLS
            {
                Id = 1,
                Nombre = "Simple",
                Descripcion = "Solo para uno"
            });

            lista.Add(new TipoHabitacionCLS {
                Id = 2,
                Nombre = "Doble",
                Descripcion = "Hecho para 2 personas"
            });
            return lista;
        }
    }
}
