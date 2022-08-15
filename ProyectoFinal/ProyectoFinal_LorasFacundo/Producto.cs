using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Producto
    {
        public int Id { get; set; }
        public int Stock { get; set; }
        public int IdUsuario { get; set; }
        public double Costo { get; set; }
        public string Descripciones { get; set; }
        public double PrecioVenta { get; set; }

    }
}
