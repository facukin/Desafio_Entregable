using Clase_08_08.Models;
using System.Data.SqlClient;

namespace Clase_08_08.Handlers
{
    public class UsuarioHandler : DbHandler
    {
        public static List<Usuario> GetUsuarios(int id)
        {
            List<Usuario> usuarios = new List<Usuario>();


            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Usuario WHERE Id = @id;", sqlConnection))
                {
                    SqlParameter parametroId = new SqlParameter();

                    parametroId.ParameterName = "id";
                    parametroId.Value = id;
                    parametroId.SqlDbType = System.Data.SqlDbType.BigInt;

                    sqlCommand.Parameters.Add(parametroId);

                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Usuario usuario = new Usuario();
                                usuario.Id = Convert.ToInt32(dataReader["Id"]);
                                usuario.Nombre = dataReader["Nombre"].ToString();
                                usuario.Apellido = dataReader["Apellido"].ToString();
                                usuario.Mail = dataReader["Mail"].ToString();
                                usuario.NombreUsuario = dataReader["NombreUsuario"].ToString();
                                usuario.Contraseña = dataReader["Contraseña"].ToString();

                                usuarios.Add(usuario);

                            }
                        }

                        sqlConnection.Close();
                    }
                }

            }

            return usuarios;

        }

        public static void DeleteUsuario(int id)
        {

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {


                    string queryDelete = "DELETE FROM Usuario WHERE Id = @id;"; /*con el @ le decimos a SQL que esto es un parametro que le vamos a pasar de afuera, en este caso lo hardcodeamos con id=1*/

                    SqlParameter parametro = new SqlParameter();

                    parametro.ParameterName = "id";
                    parametro.Value = id;
                    parametro.SqlDbType = System.Data.SqlDbType.BigInt;

                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(parametro);
                        sqlCommand.ExecuteNonQuery(); /*se ejecuta el delete*/

                    }

                    sqlConnection.Close();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static void UpdateUsuario(Usuario usuario)
        {

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {


                    string queryUpdate = "UPDATE [SistemaGestion].[dbo].[Usuario] SET Contraseña = @nuevaContraseña, NombreUsuario = @nuevoUsuario, Apellido = @nuevoApellido, Nombre = @nuevoNombre, Mail = @nuevoMail  WHERE Id = @idUsuario;";


                    SqlParameter parametroUsuarioId = new SqlParameter();

                    parametroUsuarioId.ParameterName = "idUsuario";
                    parametroUsuarioId.Value = usuario.Id;
                    parametroUsuarioId.SqlDbType = System.Data.SqlDbType.BigInt;

                    SqlParameter parametroNuevaContraseña = new SqlParameter();

                    parametroNuevaContraseña.ParameterName = "nuevaContraseña";
                    parametroNuevaContraseña.Value = usuario.Contraseña;
                    parametroNuevaContraseña.SqlDbType = System.Data.SqlDbType.VarChar;

                    SqlParameter parametroNuevoUsuario = new SqlParameter();

                    parametroNuevoUsuario.ParameterName = "nuevoUsuario";
                    parametroNuevoUsuario.Value = usuario.NombreUsuario;
                    parametroNuevoUsuario.SqlDbType = System.Data.SqlDbType.VarChar;

                    SqlParameter parametroNuevoApellido = new SqlParameter();

                    parametroNuevoApellido.ParameterName = "nuevoApellido";
                    parametroNuevoApellido.Value = usuario.Apellido;
                    parametroNuevoApellido.SqlDbType = System.Data.SqlDbType.VarChar;

                    SqlParameter parametroNuevoNombre = new SqlParameter();

                    parametroNuevoNombre.ParameterName = "nuevoNombre";
                    parametroNuevoNombre.Value = usuario.Nombre;
                    parametroNuevoNombre.SqlDbType = System.Data.SqlDbType.VarChar;

                    SqlParameter parametroNuevoMail = new SqlParameter();

                    parametroNuevoMail.ParameterName = "nuevoMail";
                    parametroNuevoMail.Value = usuario.Mail;
                    parametroNuevoMail.SqlDbType = System.Data.SqlDbType.VarChar;


                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryUpdate, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(parametroUsuarioId);
                        sqlCommand.Parameters.Add(parametroNuevaContraseña);
                        sqlCommand.Parameters.Add(parametroNuevoNombre);
                        sqlCommand.Parameters.Add(parametroNuevoApellido);
                        sqlCommand.Parameters.Add(parametroNuevoMail);
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

        public static void InsertUsuario(Usuario usuario)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {


                    string queryInsert = "INSERT INTO [SistemaGestion].[dbo].[Usuario] (Nombre, Apellido, NombreUsuario, Contraseña, Mail) "
                        + "VALUES (@nombre, @apellido, @nombreusuario, @contraseña, @mail);";

                    SqlParameter parametroNombre = new SqlParameter("nombre", System.Data.SqlDbType.VarChar) { Value = usuario.Nombre };
                    SqlParameter parametroApellido = new SqlParameter("apellido", System.Data.SqlDbType.VarChar) { Value = usuario.Apellido };
                    SqlParameter parametroNombreUsuario = new SqlParameter("nombreusuario", System.Data.SqlDbType.VarChar) { Value = usuario.NombreUsuario };
                    SqlParameter parametroContraseña = new SqlParameter("contraseña", System.Data.SqlDbType.VarChar) { Value = usuario.Contraseña };
                    SqlParameter parametroMail = new SqlParameter("mail", System.Data.SqlDbType.VarChar) { Value = usuario.Mail };

                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(parametroNombre);
                        sqlCommand.Parameters.Add(parametroApellido);
                        sqlCommand.Parameters.Add(parametroNombreUsuario);
                        sqlCommand.Parameters.Add(parametroContraseña);
                        sqlCommand.Parameters.Add(parametroMail);

                        sqlCommand.ExecuteScalar(); /*funciona igual que el nonquery, pero como ahora vamos a meter datos, no a pedirlos, usamos Scalar para ejecutar el comando*/
                    }

                    sqlConnection.Close();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Usuario Login(string user, string pass)
        {
            try
            {
                Usuario usuario = new Usuario();

                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Usuarios WHERE NombreUsuario = @usuario AND Contraseña = @password", sqlConnection))
                    {
                        SqlParameter parametroUsuario = new SqlParameter("usuario", System.Data.SqlDbType.VarChar) { Value = user };
                        SqlParameter parametroPassword = new SqlParameter("password", System.Data.SqlDbType.VarChar) { Value = pass };

                        sqlConnection.Open();

                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    Usuario usuarioValidado = new Usuario();
                                    usuarioValidado.Nombre = dataReader["Nombre"].ToString();
                                    usuarioValidado.Apellido = dataReader["Apellido"].ToString();
                                    usuarioValidado.Id = Convert.ToInt32(dataReader["Id"]);
                                    usuarioValidado.Mail = dataReader["Mail"].ToString();
                                    usuarioValidado.NombreUsuario = dataReader["NombreUsuario"].ToString();
                                    usuarioValidado.Contraseña = dataReader["Contraseña"].ToString();

                                }
                            }
                        }

                        sqlConnection.Close();

                    }
                }

                return usuario;

            }

            catch
            {
                Usuario usuarioNull = new Usuario();
                usuarioNull.Nombre = "";
                usuarioNull.Apellido = "";
                usuarioNull.NombreUsuario = "";
                usuarioNull.Contraseña = "";
                usuarioNull.Mail = "";
                usuarioNull.Id = 0;

                return usuarioNull;
            }
        }


    }

}
