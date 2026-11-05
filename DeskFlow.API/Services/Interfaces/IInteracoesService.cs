using DeskFlow.API.Models.Dtos;
using DeskFlow.API.Models.Entities;

namespace DeskFlow.API.Services.Interfaces
{
    public interface IInteracoesService
    {
        Task<List<Interacao>> ObterPorChamadoId(string chamadoId);
        Task Inserir(string chamadoId, InteracaoCriarDto interacao);
    }
}