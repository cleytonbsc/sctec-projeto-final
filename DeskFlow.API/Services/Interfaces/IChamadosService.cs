using DeskFlow.API.Models.Dtos;

namespace DeskFlow.API.Services.Interfaces
{
    public interface IChamadosService
    {
        Task<ChamadoDetalhesDto?> ObterPorId(string id);
        Task<ChamadoDetalhesDto> Inserir(ChamadoCriarDto chamado);
        Task Iniciar(string id);
        Task Encerrar(string id, ChamadoEncerrarDto chamado);

        Task<List<ChamadoDetalhesDto>> ObterTodos(string? status, string? categoria,string? categoriaID, string? prioridade, DateTime? dataInicio, DateTime? dataFim);
    }
}