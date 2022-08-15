/* se ocupa de devolver nuestra clase producto */
using Microsoft.Data.SqlClient;
using System.Data;
namespace ConsoleApp1
{
    public class ProductoHandler : DbHandler
    {


    
        public List<Producto> GetProductos()
        {
            List<Producto> productos = new List<Producto>();


            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            { 
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Producto", sqlConnection))
                {
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
}

    }

   

}

