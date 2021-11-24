namespace IatecProjeto.Models
{
    internal class Evento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Local { get; set; }
        public string Tipo { get; set; }
        public DateTime DataHora { get; set; }

    }
}
