using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;

namespace CapaDatos
{
    public class CamaDAL:CadenaDAL
    {
        public List<CamaCLS> listarCama()
        {
            List<CamaCLS> lista = null;
            using (SqlConnection cn = new SqlConnection(Cadena))
            {
                try
                {
                    //abrir conecion
                    cn.Open();
                    //llamar SP
                    using (SqlCommand comand = new SqlCommand("uspListarCama", cn))
                    {
                        comand.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = comand.ExecuteReader();
                        if (drd != null)
                        {
                            lista = new List<CamaCLS>();
                            CamaCLS oCamaCLS;
                            int posId = drd.GetOrdinal("IdCama");
                            int posNombre = drd.GetOrdinal("Nombre");
                            int posDescripcion = drd.GetOrdinal("Descripcion");
                            while (drd.Read())
                            {
                                oCamaCLS = new CamaCLS();
                                oCamaCLS.IdCama = drd.IsDBNull(posId) ? 0: drd.GetInt32(posId);
                                oCamaCLS.Nombre = drd.IsDBNull(posNombre) ? string.Empty: drd.GetString(posNombre);
                                oCamaCLS.Descripcion = drd.IsDBNull(posDescripcion)? string.Empty: drd.GetString(posDescripcion);

                                lista.Add(oCamaCLS);

                            }
                        }
                    }
                    //cerrar la conecion
                    cn.Close();
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Error de Conecion" + ex.Message);
                }
                finally
                {
                    cn.Close();
                }
            }
            return lista;
        }      
    }
}
