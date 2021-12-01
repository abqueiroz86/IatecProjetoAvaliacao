using System.Reflection;
using IatecProjeto.Controllers;
using IatecProjeto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace IatecProjeto
{
    class Program
    {
        static void Main(string[] args)
        {
            // TESTE
            /*
            var usuario = new Usuario() { Nome = "Daiane", Login = "daiane_iatec", Senha = "123456" };
            var controller = new UsuariosController();
            controller.Add(usuario);

            using (var contexto = new ProjetoContext())
            {
                var eventoUsuario = new EventoUsuario() { UsuarioId = 1, EventoId = 2 };
                contexto.EventosUsuarios.Add(eventoUsuario);
                contexto.SaveChanges();
            }
            */


            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllersWithViews();

            builder.Services.AddCors();

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Projeto Avaliação Iatec - API",
                    Description = "API desenvolvida em ASP.NET Core",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Example Contact",
                        Url = new Uri("https://example.com/contact")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Example License",
                        Url = new Uri("https://example.com/license")
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });

            var app = builder.Build();

            app.UseCors(x => x
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true)
                    .AllowCredentials());

            app.UseSwagger();
            app.UseSwaggerUI();

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
        }
    }
}