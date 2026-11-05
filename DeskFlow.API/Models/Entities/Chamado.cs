using DeskFlow.API.Models.Dtos; // Adicionado para enxergar o DTO
using DeskFlow.API.Models.Enums;

namespace DeskFlow.API.Models.Entities
{
    public class Chamado
    {
        public Chamado() { }

        public Chamado(ChamadoCriarDto dto)
        {
            Titulo = dto.Titulo;
            Descricao = dto.Descricao;
            Prioridade = dto.Prioridade;
            SolicitanteNome = dto.SolicitanteNome;
            CategoriaId = dto.CategoriaId;
        }

        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;

        public string Prioridade { get; set; } = PrioridadeChamado.Baixa.ToString();
        public string Status { get; set; } = StatusChamado.Aberto.ToString();

        public string SolicitanteNome { get; set; } = string.Empty;

        public DateTime DataAbertura { get; set; } = DateTime.UtcNow;

        public DateTime? DataFechamento { get; set; }

        public string? Solucao { get; set; }

        public string CategoriaId { get; set; } = string.Empty;

        public virtual Categoria? Categoria { get; set; }

        public virtual ICollection<Interacao> Interacoes { get; set; } = new List<Interacao>();

        public void Update(Chamado chamado)
        {
            Status = chamado.Status;
            DataFechamento = chamado.DataFechamento;
            Solucao = chamado.Solucao;
        }
    }
}
