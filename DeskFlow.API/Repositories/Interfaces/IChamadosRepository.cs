using DeskFlow.API.Models.Dtos;
using DeskFlow.API.Models.Entities;

namespace DeskFlow.API.Repositories.Interfaces
{
    public interface IChamadosRepository
    {
        Task<List<Chamado>> ObterTodos();
        Task<Chamado> ObterPorId(string id);
        Task Inserir(Chamado chamado);
        Task Iniciar(Chamado chamado);
        Task Encerrar(Chamado chamado);
    }
}