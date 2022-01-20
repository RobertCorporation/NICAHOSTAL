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
    public class CamaDAL : CadenaDAL
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
                                oCamaCLS.IdCama = drd.IsDBNull(posId) ? 0 : drd.GetInt32(posId);
                                oCamaCLS.Nombre = drd.IsDBNull(posNombre) ? string.Empty : drd.GetString(posNombre);
                                oCamaCLS.Descripcion = drd.IsDBNull(posDescripcion) ? string.Empty : drd.GetString(posDescripcion);

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

        public List<CamaCLS> BuscarPorNombre(string nombre)
        {
            List<CamaCLS> _lista = null;      
            using (SqlConnection con = new SqlConnection(Cadena))
            {
                try
                {
                    // Abrir Conexion
                    con.Open();
                    //LLamar al SP
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarCama", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombreCama", nombre);
                        SqlDataReader read = cmd.ExecuteReader();
                        if (read != null)
                        {
                            _lista = new List<CamaCLS>();
                            CamaCLS ocama;
                            int posId = read.GetOrdinal("IdCama");
                            int posNombre = read.GetOrdinal("Nombre");
                            int posDescripcion = read.GetOrdinal("Descripcion");

                            while (read.Read())
                            {
                                ocama = new CamaCLS();
                                ocama.IdCama = read.IsDBNull(posId) ? 0 : read.GetInt32(posId);
                                ocama.Nombre = read.IsDBNull(posNombre) ? string.Empty : read.GetString(posNombre);
                                ocama.Descripcion = read.IsDBNull(posDescripcion) ? string.Empty : read.GetString(posDescripcion);
                                _lista.Add(ocama);
                            }
                        }
                       
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ha ocurrido Un error!!!" + ex.Message.ToString());
                }
                finally
                {
                    con.Close();
                }
            }   
            return _lista;
        }
         
    }
}
