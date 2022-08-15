/* se ocupa de devolver nuestra clase producto */
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    public class ProductoHandler : DbHandler
    {


    
        public List<Producto> GetProductos(int id)
        {
            List<Producto> productos = new List<Producto>();


            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            { 
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Producto WHERE Id = @id;", sqlConnection))
                {
                    SqlParameter parametroId = new SqlParameter("id", SqlDbType.BigInt);
                    parametroId.Value = id;
                    sqlConnection.Open();

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
                                sqlCommand.Parameters.Add(parametroId);
                                sqlCommand.ExecuteScalar();

                                }
                        }

                            sqlConnection.Close();
                    }
                }

            }

                return productos;

        }
    

    public List<string> GetTodasLasDescripcionesConDataAdapter()
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

        public void Delete(int id)
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

        public void AgregarProducto(Producto producto)
        {
            try
            { 
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                string queryInsert = "INSERT INTO [SistemaGestion].[dbo].[Producto] ('Descripciones', 'Costo', PrecioVenta', 'Stock', IdUsuario' " +
                    "VALUE (@Descripciones, @Costo, @PrecioVenta, @Stock, @IdUsuario;";

                SqlParameter pDescripciones = new SqlParameter("Descripciones", SqlDbType.VarChar) { Value = producto.Descripciones }; /*el nombre que le damos al parametro tiene que ser igual al @ que le vamos a asociar*/
                SqlParameter pCosto = new SqlParameter("Costo", SqlDbType.BigInt) { Value = producto.Costo };
                SqlParameter pPrecioVenta = new SqlParameter("PrecioVenta", SqlDbType.BigInt) { Value=producto.PrecioVenta };
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

    }

   

}

