using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_08_08.DTOs
{
    public class PutProducto
    {
        public int Id { get; set; }
        public string Descripciones { get; set; }

        public int Costo { get; set; }

        public int PrecioVenta { get; set; }

        public int Stock { get; set; }

        public int IdUsuario { get; set; }
    }

    public class PostProducto
    {
        public int Id { get; set; }
        public string Descripciones { get; set; }

        public int Costo { get; set; }

        public int PrecioVenta { get; set; }

        public int Stock { get; set; }

        public int IdUsuario { get; set; }

    }

    public class GetProducto
    {
        public int Id { get; set; }
        public string Descripciones { get; set; }

        public int Costo { get; set; }

        public int PrecioVenta { get; set; }

        public int Stock { get; set; }

        public int IdUsuario { get; set; }

    }
}
