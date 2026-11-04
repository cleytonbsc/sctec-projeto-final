using DeskFlow.API.Models.Entities;

namespace DeskFlow.API.Services.Interfaces
{
    public interface ICategoriasService
    {
        Task<List<Categoria>> ObterTodos();
        Task<Categoria> ObterPorId(string id);
        Task Inserir(Categoria categoria);
        Task Deletar(string id);
        Task Atualizar(Categoria categoria, string id);
    }
}