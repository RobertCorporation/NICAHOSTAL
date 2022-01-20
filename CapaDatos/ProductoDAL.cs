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
    public class ProductoDAL:CadenaDAL
    {
        public List<ProductoCLS> Listar()
        {
            List<ProductoCLS> _listar = null;
            using (SqlConnection con = new SqlConnection(Cadena))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("uspListarProductos", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader read = cmd.ExecuteReader();
                        if (read != null)
                        {
                            _listar = new List<ProductoCLS>();
                            ProductoCLS producto;
                            int posIdProducto = read.GetOrdinal("IdProducto");
                            int posNombreProducto = read.GetOrdinal("Nombre");
                            int posNombreMarca = read.GetOrdinal("NombreMarca");
                            int posPrecioVenta = read.GetOrdinal("PrecioVenta");
                            int posStock = read.GetOrdinal("Stock");

                            while (read.Read())
                            {
                                producto = new ProductoCLS();
                                producto.IdProducto = read.IsDBNull(posIdProducto) ? 0 : read.GetInt32(posIdProducto);
                                producto.NombreProducto = read.IsDBNull(posNombreProducto) ? string.Empty : read.GetString(posNombreProducto).ToUpper();
                                producto.NombreMarca = read.IsDBNull(posNombreMarca) ? string.Empty : read.GetString(posNombreMarca);
                                producto.PrecioVenta = read.IsDBNull(posPrecioVenta) ? 0 : read.GetDecimal(posPrecioVenta);
                                producto.Stock = read.IsDBNull(posStock) ? 0 : read.GetDecimal(posStock);
                                producto.Denominacion = read.IsDBNull(posStock) ? string.Empty :
                                (read.GetDecimal(posStock) > 50 ? "Alto" : "Bajo");
                                _listar.Add(producto);
                            }
                        }
                     
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ha ocurrido un error De conexion! " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
                                      
            }
            return _listar;
        }

        public List<ProductoCLS> BuscarPorNombre(string nombre)
        {
            List<ProductoCLS> _resultado = null;
            using (SqlConnection con = new SqlConnection(Cadena))
            {
                try
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("uspFiltrarProductos", con))
                    {
                        try
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@nombre", nombre);                       
                            SqlDataReader read = cmd.ExecuteReader();
                            
                            if (read != null)
                            {
                                _resultado = new List<ProductoCLS>();
                                ProductoCLS oProducto;
                                int posIdProd = read.GetOrdinal("IdProducto");
                                int posNombreProducto = read.GetOrdinal("Nombre");
                                int posNombreMarca = read.GetOrdinal("NombreMarca");
                                int posPrecioVenta = read.GetOrdinal("PrecioVenta");
                                int posStock = read.GetOrdinal("Stock");

                                while (read.Read())
                                {
                                    oProducto = new ProductoCLS();
                                    oProducto.IdProducto = read.IsDBNull(posIdProd) ? 0 : read.GetInt32(posIdProd);
                                    oProducto.NombreProducto = read.IsDBNull(posNombreProducto) ? string.Empty : read.GetString(posNombreProducto).ToUpper();
                                    oProducto.NombreMarca = read.IsDBNull(posNombreMarca) ? string.Empty : read.GetString(posNombreMarca);
                                    oProducto.PrecioVenta = read.IsDBNull(posPrecioVenta) ? 0 : read.GetDecimal(posPrecioVenta);
                                    oProducto.Stock = read.IsDBNull(posStock) ? 0 : read.GetDecimal(posStock);
                                    oProducto.Denominacion = read.IsDBNull(posStock) ?  string.Empty : (read.GetDecimal(posStock) > 50 ? "Alto" : "Bajo");
                                    _resultado.Add(oProducto);
                                }
                            }
                        }
                        catch (Exception ex)
                        {            
                            Console.WriteLine(ex.Message.ToString());
                        }
                        con.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());                   
                }

                con.Close();
            }
            return _resultado;
        }
    }
}
