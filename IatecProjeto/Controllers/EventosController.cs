using IatecProjeto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IatecProjeto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController
    {
        /// <summary>
        /// Insere usuário
        /// </summary>
        [HttpPost]
        public Evento Add(Evento evento)
        {
            using (var contexto = new ProjetoContext())
            {
                contexto.Add(evento);
                contexto.SaveChanges();

                return evento;
            }
        }
    }
}
