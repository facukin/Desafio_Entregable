namespace Clase_15_8_API_Update_Put_Delete.Controllers.DTOs
{
    public class PutUsuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string NombreUsuario { get; set; }

        public string Contraseña { get; set; }

        public string Mail { get; set; }
    }

    public class PostUsuario
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string NombreUsuario { get; set; }

        public string Contraseña { get; set; }

        public string Mail { get; set; }

    }

    public class GetUsuario
    {
        public string Id { get; set; }

    }
}
