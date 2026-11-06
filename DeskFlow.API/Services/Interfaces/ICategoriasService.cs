using DeskFlow.API.Models.Dtos;
using DeskFlow.API.Models.Entities;

namespace DeskFlow.API.Services.Interfaces
{
    public interface ICategoriasService
    {
        Task<List<Categoria>> ObterTodos();
        Task<Categoria> ObterPorId(string id);
        Task Inserir(CategoriasDto categoria);
        Task Deletar(string id);
        Task Atualizar(CategoriasDto categoria, string id);
    }
}