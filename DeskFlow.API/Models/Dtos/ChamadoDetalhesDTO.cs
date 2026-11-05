using DeskFlow.API.Models.Entities;

namespace DeskFlow.API.Models.Dtos;

public class ChamadoDetalhesDto
{
    public ChamadoDetalhesDto(Chamado chamado)
    {
        Id = chamado.Id;
        Titulo = chamado.Titulo;
        Descricao = chamado.Descricao;
        Prioridade = chamado.Prioridade;
        Status = chamado.Status;
        SolicitanteNome = chamado.SolicitanteNome;
        DataAbertura = chamado.DataAbertura;
        DataFechamento = chamado.DataFechamento;
        Solucao = chamado.Solucao;
        CategoriaId = chamado.CategoriaId;
        
        // Pega o nome de forma segura se a navegação estiver carregada
        CategoriaNome = chamado.Categoria?.Nome ?? "Sem Categoria";

        if (chamado.Interacoes != null)
        {
            Interacoes = chamado.Interacoes.Select(i => new InteracaoDetalhesDto
            {
                Id = i.Id,
                Autor = i.Autor,
                Mensagem = i.Mensagem,
                DataRegistro = i.DataRegistro

            }).ToList();
        }
    }

    public ChamadoDetalhesDto() { }

    public string Id { get; set; } = string.Empty;
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string Prioridade { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string SolicitanteNome { get; set; } = string.Empty;
    public DateTime DataAbertura { get; set; }
    public DateTime? DataFechamento { get; set; }
    public string? Solucao { get; set; }
    public string CategoriaId { get; set; } = string.Empty;
    public string CategoriaNome { get; set; } = string.Empty;

    public List<InteracaoDetalhesDto> Interacoes { get; set; } = new List<InteracaoDetalhesDto>();
}
