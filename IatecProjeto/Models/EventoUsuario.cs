namespace IatecProjeto.Models
{
    public class EventoUsuario
    {
        public int UsuarioId { get; set; }
        public int EventoId { get; set; }
        public Evento Evento { get; set; }
    }
}
