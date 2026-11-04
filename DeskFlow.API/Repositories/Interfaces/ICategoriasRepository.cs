using DeskFlow.API.Models.Entities;

namespace DeskFlow.API.Repositories.Interfaces
{
    public interface ICategoriasRepository
    {
        Task<List<Categoria>> ObterTodos();
        Task<Categoria> ObterPorId(string id);
        Task Inserir(Categoria categoria);
        Task Deletar(Categoria categoria);
        Task Atualizar(Categoria categoria);
    }
}