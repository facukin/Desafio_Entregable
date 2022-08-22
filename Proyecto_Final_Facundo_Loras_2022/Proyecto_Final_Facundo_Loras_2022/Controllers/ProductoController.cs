using Clase_08_08.DTOs;
using Clase_08_08.Handlers;
using Clase_08_08.Models;
using Clase_15_8_API_Update_Put_Delete.Controllers.DTOs;
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
    public class ProductoController : ControllerBase
    {


        [HttpGet("{idProducto}")]

        public List<Producto> GetProductos(int idProducto)
        {
            return ProductoHandler.GetProductos(idProducto);
        }



        [HttpDelete]
        public void Delete([FromBody] int id)
        {
            ProductoHandler.Delete(id);
        }



        [HttpPut]
        public void AgregarProducto([FromBody] Producto producto)
        {
            ProductoHandler.AgregarProducto(producto);
        }



        [HttpPost]
        public void UpdateProducto([FromBody] Producto producto)
        {
            ProductoHandler.UpdateProducto(producto);
        }


    }
}
