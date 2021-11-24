namespace IatecProjeto.Models
{
    internal class EventoUsuario
    {
        public int UsuarioId { get; set; }
        public int EventoId { get; set; }
        public Usuario Usuario { get; set; }
        public Evento Evento { get; set; }
    }
}
