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
    public class UsuarioController : ControllerBase
    {


        [HttpGet("{idUsuario}")]

        public List<Usuario> GetUsuario(int idUsuario)
        {
            try
            {
                return UsuarioHandler.GetUsuarios(idUsuario);
            }
            catch (Exception ex)
            {
                return null;
                Console.WriteLine(ex.Message);
            }

        }



        [HttpDelete]
        public void DeleteUsuario([FromBody] int id)
        {
            UsuarioHandler.DeleteUsuario(id);
        }



        [HttpPut]
        public void UpdateUsuario([FromBody] Usuario usuario)
        {
            UsuarioHandler.UpdateUsuario(usuario);
        }



        [HttpPost]
        public void InsertUsuario([FromBody] Usuario usuario)
        {
            UsuarioHandler.InsertUsuario(usuario);
        }


    }
}
