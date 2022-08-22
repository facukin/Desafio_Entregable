/* se ocupa de devolver nuestra clase producto */
using Clase_08_08.Models;
using System.Data;
using System.Data.SqlClient;

namespace Clase_08_08.Handlers
{
    public class ProductoHandler : DbHandler
    {



        public static List<Producto> GetProductos(int id)
        {
            List<Producto> productos = new List<Producto>();


            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Producto WHERE Id = @id;", sqlConnection))
                {
                    SqlParameter parametroId = new SqlParameter("id", SqlDbType.BigInt);
                    parametroId.Value = id;
                    sqlConnection.Open();

                    sqlCommand.Parameters.Add(parametroId);

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Producto producto = new Producto();
                                producto.Id = Convert.ToInt32(dataReader["Id"]);
                                producto.Stock = Convert.ToInt32(dataReader["Stock"]);
                                producto.IdUsuario = Convert.ToInt32(dataReader["IdUsuario"]);
                                producto.Costo = Convert.ToInt32(dataReader["Costo"]);
                                producto.Descripciones = dataReader["Descripciones"].ToString();
                                producto.PrecioVenta = Convert.ToInt32(dataReader["PrecioVenta"]);

                                productos.Add(producto);

                            }
                        }

                        sqlConnection.Close();
                    }
                }

            }

            return productos;

        }


        public static List<string> GetTodasLasDescripcionesConDataAdapter()
        {
            List<string> descripciones = new List<string>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))

            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Producto", sqlConnection);

                sqlConnection.Open();

                DataSet resultado = new DataSet();

                sqlDataAdapter.Fill(resultado);
                sqlConnection.Close();

            }

            return descripciones;

        }

        List<string> GetTodasLasDescripcionesConDataReader()
        {
            List<string> descripciones = new List<string>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))

            using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Producto WHERE Id = @idProducto", sqlConnection))

            {
                sqlConnection.Open();
                /*------------------------------------------------- PARAMETROS
                SqlParameter parametro = new SqlParameter();

                int idProducto = 3;

                parametro.ParameterName = "parametro";
                parametro.SqlDbType = System.Data.SqlDbType.Int;
                parametro.Value = idProducto;

                sqlCommand.Parameters.Add(parametro);
                --------------------------------------------------*/
                using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                {
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            string descripcionProducto = dataReader.GetString(1);
                            descripciones.Add(descripcionProducto);
                        }
                    }
                }

                sqlConnection.Close();
            }
            return descripciones;

        }

        public static void Delete(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryDelete = "DELETE FROM [SistemaGestion].[dbo].[Producto] WHERE Id = @id;";

                SqlParameter parametroDelete = new SqlParameter("id", SqlDbType.BigInt);
                parametroDelete.Value = id;

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                {
                    sqlCommand.Parameters.Add(parametroDelete);
                    sqlCommand.ExecuteScalar();
                }

                sqlConnection.Close();
            }
        }

        public static void AgregarProducto(Producto producto)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryInsert = "INSERT INTO [SistemaGestion].[dbo].[Producto] (Descripciones, Costo, PrecioVenta, Stock, IdUsuario) " + 
                        "VALUES (@Descripciones, @Costo, @PrecioVenta, @Stock, @IdUsuario);";

                    SqlParameter pDescripciones = new SqlParameter("Descripciones", SqlDbType.VarChar) { Value = producto.Descripciones }; /*el nombre que le damos al parametro tiene que ser igual al @ que le vamos a asociar*/
                    SqlParameter pCosto = new SqlParameter("Costo", SqlDbType.BigInt) { Value = producto.Costo };
                    SqlParameter pPrecioVenta = new SqlParameter("PrecioVenta", SqlDbType.BigInt) { Value = producto.PrecioVenta };
                    SqlParameter pStock = new SqlParameter("Stock", SqlDbType.BigInt) { Value = producto.Stock };
                    SqlParameter pIdUsuario = new SqlParameter("IdUsuario", SqlDbType.BigInt) { Value = producto.IdUsuario };

                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(pDescripciones);
                        sqlCommand.Parameters.Add(pCosto);
                        sqlCommand.Parameters.Add(pPrecioVenta);
                        sqlCommand.Parameters.Add(pStock);
                        sqlCommand.Parameters.Add(pIdUsuario);

                        sqlCommand.ExecuteNonQuery();


                    }

                    sqlConnection.Close();

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static void UpdateProducto(Producto producto)
        {

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {


                    string queryUpdate = "UPDATE [SistemaGestion].[dbo].[Producto] SET Descripciones = @nuevaDescripcion, Costo = @nuevoCosto, PrecioVenta = @nuevoPrecioVenta, Stock = @nuevoStock, IdUsuario = @nuevoIdUsuario  WHERE Id = @idProducto;";


                    SqlParameter parametroProductoId = new SqlParameter();

                    parametroProductoId.ParameterName = "idProducto";
                    parametroProductoId.Value = producto.Id;
                    parametroProductoId.SqlDbType = System.Data.SqlDbType.BigInt;

                    SqlParameter parametroNuevaDescripcion = new SqlParameter();

                    parametroNuevaDescripcion.ParameterName = "nuevaDescripcion";
                    parametroNuevaDescripcion.Value = producto.Descripciones;
                    parametroNuevaDescripcion.SqlDbType = System.Data.SqlDbType.VarChar;

                    SqlParameter parametroNuevoCosto = new SqlParameter();

                    parametroNuevoCosto.ParameterName = "nuevoCosto";
                    parametroNuevoCosto.Value = producto.Costo;
                    parametroNuevoCosto.SqlDbType = System.Data.SqlDbType.BigInt;


                    SqlParameter parametroNuevoStock = new SqlParameter();

                    parametroNuevoStock.ParameterName = "nuevoStock";
                    parametroNuevoStock.Value = producto.Stock;
                    parametroNuevoStock.SqlDbType = System.Data.SqlDbType.BigInt;

                    SqlParameter parametroNuevoPrecioVenta = new SqlParameter();

                    parametroNuevoPrecioVenta.ParameterName = "nuevoPrecioVenta";
                    parametroNuevoPrecioVenta.Value = producto.PrecioVenta;
                    parametroNuevoPrecioVenta.SqlDbType = System.Data.SqlDbType.BigInt;

                    SqlParameter parametroNuevoUsuario = new SqlParameter();

                    parametroNuevoUsuario.ParameterName = "nuevoIdUsuario";
                    parametroNuevoUsuario.Value = producto.IdUsuario;
                    parametroNuevoUsuario.SqlDbType = System.Data.SqlDbType.BigInt;


                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryUpdate, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(parametroProductoId);
                        sqlCommand.Parameters.Add(parametroNuevaDescripcion);
                        sqlCommand.Parameters.Add(parametroNuevoCosto);
                        sqlCommand.Parameters.Add(parametroNuevoPrecioVenta);
                        sqlCommand.Parameters.Add(parametroNuevoStock);
                        sqlCommand.Parameters.Add(parametroNuevoUsuario);
                        sqlCommand.ExecuteNonQuery(); /*se ejecuta el update*/

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

