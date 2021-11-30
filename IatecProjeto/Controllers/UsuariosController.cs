using System.Net;
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
            using (var contexto = new ProjetoContext())
            {
                return await contexto
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
            using (var contexto = new ProjetoContext())
            {
                var usuario = await contexto
                    .Usuarios
                    .Where(u => u.Id == id)
                    .ToListAsync();

                if (usuario == null)
                    return NotFound();

                return usuario;
            }
        }

        /// <summary>
        /// Retorna os eventos de um usuário
        /// </summary>
        [HttpGet("~/api/Usuarios/GetEventosUsuarios")]
        public async Task<ActionResult<IEnumerable<EventoUsuario>>> GetEventosUsuarios(int id)
        {
            using (var contexto = new ProjetoContext())
            {
                return await contexto
                    .EventosUsuarios
                    .Where(u => u.UsuarioId == id)
                    .Include(t => t.Evento)
                    .ToListAsync();
            }
        }

        /// <summary>
        /// Insere usuário
        /// </summary>
        [HttpPost]
        public Usuario Add(Usuario usuario)
        {
            using (var contexto = new ProjetoContext())
            {
                contexto.Add(usuario);
                contexto.SaveChanges();

                return usuario;
            }
        }

        /// <summary>
        /// Exclui usuário
        /// </summary>
        [HttpGet("~/api/Usuarios/ExcluiUsuarios")]
        public async Task<ActionResult<IEnumerable<Usuario>>> Delete(int id)
        {
            using (var contexto = new ProjetoContext())
            {
                Usuario usuario = contexto.Usuarios.Find(id);
                if (usuario == null)
                {
                    return NotFound();
                }

                contexto.Usuarios.Remove(usuario);

                try
                {
                    contexto.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    return NotFound();
                }

                return Ok();
            }
        }
    }
}