
using IatecProjeto.Models;
using Microsoft.EntityFrameworkCore;

namespace IatecProjeto.Controllers
{
    internal class ProjetoContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<EventoUsuario> EventosUsuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<EventoUsuario>()
                .HasKey(pp => new { pp.UsuarioId, pp.EventoId });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=iatecdb;Trusted_Connection=true;");
        }
    }
}