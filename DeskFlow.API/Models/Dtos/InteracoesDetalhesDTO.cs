namespace DeskFlow.API.Models.Dtos
{
    public class InteracaoDetalhesDto
    {
        public string Id { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public string Mensagem { get; set; } = string.Empty;
        public DateTime DataRegistro { get; set; }
    }
}
