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

        public int GuardarCama(CamaCLS oCamaCLS)
        {
            int resultado = 0;
            using (SqlConnection con = new SqlConnection(Cadena))
            {
                try
                {
                    //Abrir Conexion
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("uspGuardarCama", con))
                    {
                        try
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@id", oCamaCLS.IdCama);
                            cmd.Parameters.AddWithValue("@nombre", oCamaCLS.Nombre);
                            cmd.Parameters.AddWithValue("@descripcion", oCamaCLS.Descripcion);
                            resultado = cmd.ExecuteNonQuery();
                        }
                        catch (SqlException ex)
                        {
                            Console.Error.WriteLine("Ha ocurrido un Error " + ex.ErrorCode, ex.Errors, ex.Message, ex.Procedure, ex.StackTrace);
                            con.Close();
                        }
                        con.Close();
                    }
                   con.Close();
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message.ToString());
                    con.Close();
                    
                }

            }

            return resultado;
        }

        public CamaCLS RecuperarCamaPorId(int id)
        {
            CamaCLS oCamaCLS = null;
            using (SqlConnection con = new SqlConnection(Cadena))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd =new SqlCommand("uspRecuperarCama", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);
                        SqlDataReader read = cmd.ExecuteReader();
                        if (read != null)
                        {
                            int posId = read.GetOrdinal("IdCama");
                            int posNombre = read.GetOrdinal("Nombre");
                            int posDescripcion = read.GetOrdinal("Descripcion");

                            while (read.Read())
                            {
                                oCamaCLS = new CamaCLS();
                                oCamaCLS.IdCama = read.IsDBNull(posId) ? 0 : read.GetInt32(posId);
                                oCamaCLS.Nombre = read.IsDBNull(posNombre) ? "" : read.GetString(posNombre);
                                oCamaCLS.Descripcion = read.IsDBNull(posDescripcion) ? "" : read.GetString(posDescripcion);
                                
                            }
                        }

                        con.Close();
                    }
                }
                catch (SqlException ex)
                {
                    Console.Error.WriteLine(ex.Message.ToString());
                    con.Close();
                    
                }
            }
                return oCamaCLS;
        }
        
        public int EliminarCama(int IdCama)
        {
            int respuesta = 0;
            using (SqlConnection con = new SqlConnection(Cadena))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("uspEliminarCama", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", IdCama);
                        respuesta = cmd.ExecuteNonQuery();

                    }
                    con.Close();
                }
                catch (SqlException ex)
                {
                    Console.Error.WriteLine("Errro!! " + ex.Message.ToString());
                    con.Close();
                }
            }
            return respuesta;
        }
    }
}
