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
    public class VentaController : ControllerBase
    {


        [HttpGet("{idVenta}")]

        public List<Ventas> GetVentas(int idVenta)
        {
            return VentasHandler.GetVentas(idVenta);
        }



        [HttpDelete]
        public void Delete([FromBody] Ventas id)
        {
            VentasHandler.Delete(id);
        }



        [HttpPut]
        public void Update([FromBody] Ventas venta)
        {
            VentasHandler.Update(venta);
        }



        [HttpPost]
        public void Insert([FromBody] Ventas venta)
        {
            VentasHandler.Insert(venta);
        }

    }
}
