using DeskFlow.API.Models.Entities;

namespace DeskFlow.API.Repositories.Interfaces
{
    public interface IInteracoesRepository
    {
        Task<List<Interacao>> ObterPorChamadoId(string chamadoId);
        Task Inserir(Interacao interacao);
    }
}