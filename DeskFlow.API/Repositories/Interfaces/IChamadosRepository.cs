using DeskFlow.API.Models.Dtos;
using DeskFlow.API.Models.Entities;

namespace DeskFlow.API.Repositories.Interfaces
{
    public interface IChamadosRepository
    {
        Task<Chamado?> ObterPorId(string id);
        Task Inserir(Chamado chamado);
        Task Iniciar(Chamado chamado);
        Task Encerrar(Chamado chamado);
        Task<List<Chamado>> ObterTodos(string? status, string? categoria, string? categoriaID, string? prioridade, DateTime? dataInicio, DateTime? dataFim);
    }
}