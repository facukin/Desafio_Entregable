
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class VentasHandler : DbHandler
    {
        public List<Ventas> GetVentas(Ventas venta)
        {
            try
            {
                List<Ventas> ventas = new List<Ventas>();

                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM ProductoVendido;", sqlConnection))
                    {
                        sqlConnection.Open();

                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    Ventas vendido = new Ventas();
                                    vendido.Id = Convert.ToInt32(dataReader["Id"]);
                                    vendido.Comentarios = dataReader["Comentarios"].ToString();

                                    ventas.Add(vendido);
                                }
                            }
                            sqlConnection.Close();
                        }
                    }
                }
                return ventas;
           
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public void Insert(Ventas ventas)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryInsert = "INSERT INTO [SistemaGestion].[dbo].[Venta] (Id, Comentarios) VALUES ('@comentarioNuevo', '@idVenta');";

                    SqlParameter parametroComentarioNuevo = new SqlParameter("comentarioNuevo", System.Data.SqlDbType.VarChar) { Value = ventas.Comentarios };
                    SqlParameter parametroIdVenta = new SqlParameter("idVenta", System.Data.SqlDbType.BigInt) { Value = ventas.Id };

                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(parametroComentarioNuevo);
                        sqlCommand.Parameters.Add(parametroIdVenta);

                        sqlCommand.ExecuteNonQuery();
                    }
                }
           
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(Ventas ventas)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryDelete = "DELETE * FROM Ventas WHERE Id = @idVenta;";

                    SqlParameter parametroId = new SqlParameter();

                    parametroId.Value = ventas.Id;
                    parametroId.ParameterName = "IdVenta";
                    parametroId.DbType = System.Data.DbType.Int32;

                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(parametroId);
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

        public void Update(Ventas ventas)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryUpdate = "UPDATE [SistemaGestion].[dbo].[Ventas] SET Comentarios = @comentarioNuevo WHERE Id = @idventa;";

                    SqlParameter parametroComentario = new SqlParameter();
                    parametroComentario.ParameterName = "comentarioNuevo";
                    parametroComentario.Value = ventas.Comentarios;
                    parametroComentario.SqlDbType = System.Data.SqlDbType.VarChar;

                    SqlParameter parametroIdVenta = new SqlParameter();
                    parametroIdVenta.ParameterName = "idventa";
                    parametroIdVenta.Value = ventas.Id;
                    parametroIdVenta.SqlDbType = System.Data.SqlDbType.BigInt;

                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryUpdate,sqlConnection))
                    {
                        sqlCommand.Parameters.Add(parametroComentario);
                        sqlCommand.Parameters.Add(parametroIdVenta);
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