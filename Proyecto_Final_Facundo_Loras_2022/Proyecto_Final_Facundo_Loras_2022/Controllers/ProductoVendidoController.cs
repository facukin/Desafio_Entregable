using Clase_08_08.DTOs;
using Clase_08_08.Handlers;
using Clase_08_08.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_08_08.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoVendidoController : ControllerBase
    {


        [HttpGet("{idProductoVendido}")]

        public List<ProductoVendido> GetProductoVendidos(int idProductoVendido)
        {
            return ProductoVendidoHandler.GetProductoVendidos(idProductoVendido);
        }



        [HttpDelete]
        public void Delete([FromBody] ProductoVendido productoVendido)
        {
            ProductoVendidoHandler.Delete(productoVendido);
        }



        [HttpPut]
        public void UpdateStock([FromBody] ProductoVendido id)
        {
            ProductoVendidoHandler.UpdateStock(id);
        }



        [HttpPost]
        public void Insert([FromBody] ProductoVendido productoVendido)
        {
            ProductoVendidoHandler.Insert(productoVendido);
        }


    }
}
