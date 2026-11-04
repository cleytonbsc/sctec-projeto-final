namespace DeskFlow.API.Models.Entities
{
    public class Interacao
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string ChamadoId { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public string Mensagem { get; set; } = string.Empty;

        public DateTime DataRegistro { get; set; } = DateTime.UtcNow;

        public virtual Chamado Chamado { get; set; } = null!;
    }
}