using Clase_08_08.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_08_08.Handlers
{
    public class ProductoVendidoHandler : DbHandler
    {
        public static List<ProductoVendido> GetProductoVendidos(int id)
        {
            List<ProductoVendido> productosVendidos = new List<ProductoVendido>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM ProductoVendido WHERE Id = @id;", sqlConnection))
                {
                    SqlParameter parametroId = new SqlParameter("id", System.Data.SqlDbType.BigInt);

                    parametroId.Value = id;
                    parametroId.ParameterName = "id";
                    parametroId.SqlDbType = System.Data.SqlDbType.BigInt;

                    sqlCommand.Parameters.Add(parametroId);

                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                ProductoVendido productoVendido = new ProductoVendido();
                                productoVendido.Id = Convert.ToInt32(dataReader["Id"]);
                                productoVendido.Stock = Convert.ToInt32(dataReader["Stock"]);
                                productoVendido.IdProducto = Convert.ToInt32(dataReader["IdProducto"]);
                                productoVendido.IdVenta = Convert.ToInt32(dataReader["IdVenta"]);

                                productosVendidos.Add(productoVendido);
                            }
                        }

                        sqlConnection.Close();
                    }
                }
            }

            return productosVendidos;
        }

        public static void Delete(ProductoVendido productoVendido)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryDelete = "DELETE FROM ProductoVendido WHERE Id = @idprod;";

                    SqlParameter parametro = new SqlParameter();

                    parametro.ParameterName = "idprod";
                    parametro.Value = productoVendido.Id;
                    parametro.SqlDbType = System.Data.SqlDbType.BigInt;

                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(parametro);
                        sqlCommand.ExecuteNonQuery(); /*usamos nonquery porque no buscamos valores de la tabla, solo eliminamos valores.*/
                    }

                    sqlConnection.Close();

                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        public static void Insert(ProductoVendido productoVendido)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryInsert = "INSERT INTO [SistemaGestion].[dbo].[ProductoVendido] (Stock, IdProducto, IdVenta)" + "VALUES (@stock, @idprod, @idventa);";

                    SqlParameter parametroStock = new SqlParameter("stock", System.Data.SqlDbType.BigInt) { Value = productoVendido.Stock };
                    SqlParameter parametroIdProd = new SqlParameter("idprod", System.Data.SqlDbType.BigInt) { Value = productoVendido.IdProducto };
                    SqlParameter parametroIdVenta = new SqlParameter("idventa", System.Data.SqlDbType.BigInt) { Value = productoVendido.IdVenta };

                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(parametroStock);
                        sqlCommand.Parameters.Add(parametroIdProd);
                        sqlCommand.Parameters.Add(parametroIdVenta);

                        sqlCommand.ExecuteScalar();
                    }

                    sqlConnection.Close();

                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static void UpdateStock(ProductoVendido productoVendido)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryUpdate = "UPDATE [SistemaGestion].[dbo].[ProductoVendido] SET Stock = @nuevoStock WHERE Id = @idProd;";

                    SqlParameter parametroStock = new SqlParameter();

                    parametroStock.ParameterName = "nuevoStock";
                    parametroStock.Value = productoVendido.Stock;
                    parametroStock.SqlDbType = System.Data.SqlDbType.BigInt;

                    SqlParameter parametroIdProd = new SqlParameter();

                    parametroIdProd.ParameterName = "idProd";
                    parametroIdProd.Value = productoVendido.Id;
                    parametroIdProd.SqlDbType = System.Data.SqlDbType.BigInt;

                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryUpdate, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(parametroIdProd);
                        sqlCommand.Parameters.Add(parametroStock);

                        sqlCommand.ExecuteScalar();
                    }

                    sqlConnection.Close();
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
