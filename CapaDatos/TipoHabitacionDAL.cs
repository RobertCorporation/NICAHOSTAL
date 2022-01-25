using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace CapaDatos
{
    public class TipoHabitacionDAL:CadenaDAL
    {
        /*public List<TipoHabitacionCLS> listarTipoHabitacion()
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
        }*/

        public List<TipoHabitacionCLS> listarTipoHabitacion()
        {
            List<TipoHabitacionCLS> lista = null;
            using (SqlConnection cn = new SqlConnection(Cadena))
            {
                try
                {
                    //abrir conecion
                    cn.Open();
                    //llamar SP
                    using (SqlCommand comand = new SqlCommand("uspListarTipoHabitacion", cn))
                    {
                        comand.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = comand.ExecuteReader();
                        if (drd != null)
                        {
                            lista = new List<TipoHabitacionCLS>();
                            TipoHabitacionCLS oTipoHabitacionCLS;
                            int posId = drd.GetOrdinal("IdTipoHabitacion");
                            int posNombre = drd.GetOrdinal("Nombre");
                            int posDescripcion = drd.GetOrdinal("Descripcion");
                            while (drd.Read())
                            {
                                oTipoHabitacionCLS = new TipoHabitacionCLS();
                                oTipoHabitacionCLS.Id = drd.GetInt32(posId);
                                oTipoHabitacionCLS.Nombre = drd.GetString(posNombre);
                                oTipoHabitacionCLS.Descripcion = drd.GetString(posDescripcion);

                                lista.Add(oTipoHabitacionCLS);

                            }
                        }
                    }

                    //cerrar la conecion
                    cn.Close();
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Error de Conecion"+ex.Message);
                }
                finally
                {
                    cn.Close();
                }
                

            }
            return lista;

        }
        public List<TipoHabitacionCLS> FiltrarTipoHabitacion(string nombreHabitacion)
        {
            List<TipoHabitacionCLS> lista = null;
            using (SqlConnection cn = new SqlConnection(Cadena))
            {
                try
                {
                    //abrir conecion
                    cn.Open();
                    //llamar SP
                    using (SqlCommand comand = new SqlCommand("uspFiltrarTipoHabitacion", cn))
                    {
                        comand.CommandType = CommandType.StoredProcedure;
                        comand.Parameters.AddWithValue("@nombreHabitacion", nombreHabitacion);
                        SqlDataReader drd = comand.ExecuteReader();
                        if (drd != null)
                        {
                            lista = new List<TipoHabitacionCLS>();
                            TipoHabitacionCLS oTipoHabitacionCLS;
                            int posId = drd.GetOrdinal("IdTipoHabitacion");
                            int posNombre = drd.GetOrdinal("Nombre");
                            int posDescripcion = drd.GetOrdinal("Descripcion");
                            while (drd.Read())
                            {
                                oTipoHabitacionCLS = new TipoHabitacionCLS();
                                oTipoHabitacionCLS.Id = drd.GetInt32(posId);
                                oTipoHabitacionCLS.Nombre = drd.GetString(posNombre);
                                oTipoHabitacionCLS.Descripcion = drd.GetString(posDescripcion);

                                lista.Add(oTipoHabitacionCLS);

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

        public int GuardarTipoHabitacion(TipoHabitacionCLS oTipoHabitacion)
        {
            // Error
            int resultado = 0;
            using (SqlConnection con = new SqlConnection(Cadena))
            {
                try
                {
                    //Abro la conexion
                    con.Open();
                    using (SqlCommand cmd= new SqlCommand("uspGuardarTipoHabitacion", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", oTipoHabitacion.Id);
                        cmd.Parameters.AddWithValue("@nombre", oTipoHabitacion.Nombre);
                        cmd.Parameters.AddWithValue("@descripcion", oTipoHabitacion.Descripcion);
                        resultado = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    resultado = 0;
                    con.Close();
                    Console.WriteLine("Ha ocurrido un error con los datos de entradas"+e.Message);
                }
            }
            return resultado;
        }

        public TipoHabitacionCLS BuscarPorId(int Id)
        {
            TipoHabitacionCLS oTipoHabitacionCLS = null;
            using (SqlConnection con = new SqlConnection(Cadena))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("uspRecuperarTipoHabitacion", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", Id);
                        SqlDataReader read = cmd.ExecuteReader();
                        if (read != null)
                        {
                            int posId = read.GetOrdinal("IdTipoHabitacion");
                            int posNombre = read.GetOrdinal("Nombre");
                            int posDescripcion = read.GetOrdinal("Descripcion");

                            while (read.Read())
                            {
                                oTipoHabitacionCLS = new TipoHabitacionCLS();
                                oTipoHabitacionCLS.Id = read.IsDBNull(posId) ? 0 : read.GetInt32(posId);
                                oTipoHabitacionCLS.Nombre = read.IsDBNull(posNombre) ? string.Empty : read.GetString(posNombre);
                                oTipoHabitacionCLS.Descripcion = read.IsDBNull(posDescripcion) ? string.Empty : read.GetString(posDescripcion);
                            }
                        }                     
                    }
                    con.Close();
                }
                catch (SqlException ex)
                {
                    Console.Error.WriteLine("Ocurrio un error con la Conexion", ex.Message.ToString());
                    con.Close();
                }

            }
            return oTipoHabitacionCLS;
        }
    }
}
