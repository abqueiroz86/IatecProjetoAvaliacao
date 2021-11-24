using IatecProjeto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IatecProjeto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        /// <summary>
        /// Retorna todos usuários da base
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetAll()
        {
            using (var _context = new ProjetoContext())
            {
                return await _context
                    .Usuarios
                    .ToListAsync();
            }
        }

        /// <summary>
        /// Retorna um usuário específico
        /// </summary>
        [HttpGet("~/api/Usuarios/GetById")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetById(int id)
        {
            using (var _context = new ProjetoContext())
            {
                var usuario = await _context
                    .Usuarios
                    .Where(u => u.Id == id)
                    .ToListAsync();

                if (usuario == null)
                    return NotFound();

                return usuario;
            }
        }

        /// <summary>
        /// Retorna todos usuários da base
        /// </summary>
        [HttpGet("~/api/Usuarios/GetEventosUsuarios")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetEventosUsuarios()
        {
            using (var _context = new ProjetoContext())
            {
                return await _context
                    .Usuarios
                    .Include(e => e.EventosUsuarios)
                    .ToListAsync();
            }
        }
    }
}
