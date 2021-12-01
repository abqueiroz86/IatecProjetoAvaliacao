using IatecProjeto.Models;
using Microsoft.AspNetCore.Mvc;

namespace IatecProjeto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosUsuariosController
    {
        /// <summary>
        /// Insere eventoUsuario
        /// </summary>
        [HttpPost]
        public EventoUsuario Add(EventoUsuario eventoUsuario)
        {
            using (var contexto = new ProjetoContext())
            {
                contexto.Add(eventoUsuario);
                contexto.SaveChanges();

                return eventoUsuario;
            }
        }
    }
}
