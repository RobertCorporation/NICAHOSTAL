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
    }
}
