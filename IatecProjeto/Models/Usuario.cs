namespace IatecProjeto.Models
{
    internal class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public IList<EventoUsuario> EventosUsuarios { get; set; }
    }
}
