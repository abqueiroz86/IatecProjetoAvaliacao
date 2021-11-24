using IatecProjeto.Models;
using Microsoft.EntityFrameworkCore;

namespace IatecProjeto
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var contexto = new ProjetoContext())
            {
                /*
                var usuario = new Usuario() { Nome = "Antonio Bianco", Login = "abqueiroz86", Senha = "123456" };
                contexto.Add(usuario);
                contexto.SaveChanges();
                */

                /*
                var evento = new Evento() { Nome = "Entrevista", Descricao = "Projeto Iatec", Local = "Online", Tipo = "C", DataHora = DateTime.Parse("2021-12-01 08:00:00") };
                contexto.Add(evento);
                contexto.SaveChanges();
                */

                /*
                var eventousuario = new EventoUsuario() { UsuarioId = 1, EventoId = 2 };
                contexto.Add(eventousuario);
                contexto.SaveChanges();
                */


                var a = contexto
                    .Usuarios
                    .Include( e => e.EventosUsuarios )
                    .FirstOrDefault();
                Console.WriteLine(a.EventosUsuarios.First().EventoId);
            }
        }
    }
}


/*
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
*/