using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_08_08.DTOs
{
    public class PutProductoVendido
    {
        public int Id { get; set; }
        public int Stock { get; set; }

        public int IdProducto { get; set; }

        public int IdVenta { get; set; }

    }

    public class PostProductoVendido
    {
        public int Id { get; set; }
        public int Stock { get; set; }

        public int IdProducto { get; set; }

        public int IdVenta { get; set; }
    }

    public class GetProductoVendido
    {
        public int Id { get; set; }
        public int Stock { get; set; }

        public int IdProducto { get; set; }

        public int IdVenta { get; set; }
    }
}
