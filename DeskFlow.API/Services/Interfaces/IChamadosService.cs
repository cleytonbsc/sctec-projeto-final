using DeskFlow.API.Models.Dtos;

namespace DeskFlow.API.Services.Interfaces
{
    public interface IChamadosService
    {
        Task<List<ChamadoDetalhesDto>> ObterTodos();
        Task<ChamadoDetalhesDto> ObterPorId(string id);
        Task<ChamadoDetalhesDto> Inserir(ChamadoCriarDto chamado);
        Task Iniciar(string id);
        Task Encerrar(string id, ChamadoEncerrarDto chamado);
    }
}