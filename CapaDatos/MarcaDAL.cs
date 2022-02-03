using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class MarcaDAL:CadenaDAL
    {
        public List<MarcaCLS> ListarMarcas()
        {
            List<MarcaCLS> lista = null;
            using (SqlConnection cn = new SqlConnection(Cadena))
            {
                try
                {
                    //Open Connection
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspListarMarca", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlDataReader read = cmd.ExecuteReader();
                        if (read != null)
                        {
                            lista = new List<MarcaCLS>();
                            MarcaCLS oMarca;
                            int posIdMarca = read.GetOrdinal("IdMarca");
                            int posNombreMarca = read.GetOrdinal("NombreMarca");
                            int posDescripcion = read.GetOrdinal("Descripcion");

                            while (read.Read())
                            {
                                oMarca = new MarcaCLS();
                                oMarca.IdMarca =  read.IsDBNull(posIdMarca) ? 0:read.GetInt32(posIdMarca);
                                oMarca.NombreMarca = read.IsDBNull(posNombreMarca) ? string.Empty:read.GetString(posNombreMarca);
                                oMarca.Descripcion = read.IsDBNull(posDescripcion) ? string.Empty : read.GetString(posDescripcion);
                                lista.Add(oMarca);
                            }
                        }
                        
                    }
                    cn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ha ocurrido un error", ex.Message);
                    
                }
                finally
                {
                    cn.Close();
                }
            }

            return lista;
        }

        public List<MarcaCLS> BuscarPorNombre(string nombre)
        {
            List<MarcaCLS> _resutado = null;
            using (SqlConnection con = new SqlConnection(Cadena))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarMarca", con))
                    {
                        try
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@nombre", nombre);
                            SqlDataReader read = cmd.ExecuteReader();

                            if (read != null)
                            {
                                _resutado = new List<MarcaCLS>();
                                MarcaCLS oMarcar;
                                int posIdMarca = read.GetOrdinal("IdMarca");
                                int posNombre = read.GetOrdinal("NombreMarca");
                                int posDescripcion = read.GetOrdinal("Descripcion");

                                while (read.Read())
                                {
                                    oMarcar = new MarcaCLS();
                                    oMarcar.IdMarca = read.IsDBNull(posIdMarca) ? 0 : read.GetInt32(posIdMarca);
                                    oMarcar.NombreMarca = read.IsDBNull(posNombre) ? string.Empty : read.GetString(posNombre);
                                    oMarcar.Descripcion = read.IsDBNull(posDescripcion) ? string.Empty : read.GetString(posDescripcion);
                                    _resutado.Add(oMarcar);
                                }
                            }
                            
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Ha ocurrido un error con en la Busqueda uspFiltrarMarca " + ex.Message.ToString());                     
                        }
                        con.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocurio un error de Conexion a la Base de datos Detalle: " + ex.Message.ToString());
                }
                con.Close();
            }
            return _resutado;
        }

        public MarcaCLS BuscarMarcaPorID(int Id)
        {
            MarcaCLS oMarca = null;
            using (SqlConnection con = new SqlConnection(Cadena))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("uspBuscarMarcaPorId", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", Id);
                        SqlDataReader read = cmd.ExecuteReader();

                        if (read != null)
                        {
                            int posId = read.GetOrdinal("IdMarca");
                            int posNombre = read.GetOrdinal("NombreMarca");
                            int posDescripcion = read.GetOrdinal("Descripcion");

                            while (read.Read())
                            {
                                oMarca = new MarcaCLS();
                                oMarca.IdMarca = read.IsDBNull(posId) ? 0 : read.GetInt32(posId);
                                oMarca.NombreMarca = read.IsDBNull(posNombre) ? string.Empty : read.GetString(posNombre);
                                oMarca.Descripcion = read.IsDBNull(posDescripcion) ? string.Empty : read.GetString(posDescripcion);

                            }
                        }

                    }
                    con.Close();
                }
                catch (SqlException ex)
                {

                    con.Close();
                    Console.Error.WriteLine("Ha ocurrido un error de conexion " + ex.Message.ToString());
                }
            }
            return oMarca;
        }

        public int GuardarMarca(MarcaCLS oMarcaCLS)
        {
            // Error
            int resultado = 0;
            using (SqlConnection con = new SqlConnection(Cadena))
            {
                try
                {
                    //Abro la conexion
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("uspGuardarMarca", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", oMarcaCLS.IdMarca);
                        cmd.Parameters.AddWithValue("@Nombre", oMarcaCLS.NombreMarca);
                        cmd.Parameters.AddWithValue("@Descripcion", oMarcaCLS.Descripcion);
                        resultado = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    resultado = 0;
                    con.Close();
                    Console.WriteLine("Ha ocurrido un error con los datos de entradas" + e.Message);
                }
            }
            return resultado;
        }

        public int EliminarDatos(int Id)
        {
            int resultado = 0;
            using (SqlConnection con = new SqlConnection(Cadena))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("uspEliminarMarca", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", Id);
                        resultado = cmd.ExecuteNonQuery();
                        con.Close();

                    }
                }
                catch (SqlException ex)
                {

                    con.Close();
                    Console.Error.WriteLine("Ha ocurrido un error inesperado" + ex.Message.ToString());
                }

            }
            return resultado;

        }
    }
}
