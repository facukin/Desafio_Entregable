using Clase_08_08.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_08_08.Handlers
{
    public class VentasHandler : DbHandler
    {
        public static List<Ventas> GetVentas(int id)
        {
            try
            {
                List<Ventas> ventas = new List<Ventas>();

                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Venta WHERE Id = @id;", sqlConnection))
                    {
                        SqlParameter parametroId = new SqlParameter("id", System.Data.SqlDbType.BigInt);
                        parametroId.Value = id;
                        sqlConnection.Open();
                        sqlCommand.Parameters.Add(parametroId);

                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    Ventas venta = new Ventas();
                                    venta.Id = Convert.ToInt32(dataReader["Id"]);
                                    venta.Comentarios = dataReader["Comentarios"].ToString();

                                    ventas.Add(venta);

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

        public static void Insert(Ventas ventas)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryInsert = "INSERT INTO [SistemaGestion].[dbo].[Venta] (Comentarios) VALUES (@comentarioNuevo)";

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

        public static void Delete(Ventas ventas)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryDelete = "DELETE FROM Venta WHERE Id = @idVenta;";

                    SqlParameter parametroId = new SqlParameter();

                    parametroId.Value = ventas.Id;
                    parametroId.ParameterName = "idVenta";
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

        public static void Update(Ventas ventas)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryUpdate = "UPDATE [SistemaGestion].[dbo].[Venta] SET Comentarios = @comentarioNuevo WHERE Id = @idventa;";

                    SqlParameter parametroComentario = new SqlParameter();
                    parametroComentario.ParameterName = "comentarioNuevo";
                    parametroComentario.Value = ventas.Comentarios;
                    parametroComentario.SqlDbType = System.Data.SqlDbType.VarChar;

                    SqlParameter parametroIdVenta = new SqlParameter();
                    parametroIdVenta.ParameterName = "idventa";
                    parametroIdVenta.Value = ventas.Id;
                    parametroIdVenta.SqlDbType = System.Data.SqlDbType.BigInt;

                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryUpdate, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(parametroComentario);
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
    }

}