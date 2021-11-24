
using IatecProjeto.Models;
using Microsoft.EntityFrameworkCore;

namespace IatecProjeto
{
    internal class ProjetoContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=iatecdb;Trusted_Connection=true;");
        }
    }
}