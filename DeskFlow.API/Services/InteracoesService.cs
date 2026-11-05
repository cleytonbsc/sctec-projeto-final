using DeskFlow.API.Models.Dtos;
using DeskFlow.API.Models.Entities;
using DeskFlow.API.Repositories.Interfaces;
using DeskFlow.API.Services.Interfaces;

namespace DeskFlow.API.Services
{
    public class InteracoesService : IInteracoesService
    {
        private readonly IInteracoesRepository _interacoesRepository;

        public InteracoesService(IInteracoesRepository interacoesRepository)
        {
            _interacoesRepository = interacoesRepository;
        }

        public async Task<List<Interacao>> ObterPorChamadoId(string chamadoId)
        {
            return await _interacoesRepository.ObterPorChamadoId(chamadoId);
        }

        public async Task Inserir(String id, InteracaoCriarDto interacao)
        {
            
            Interacao interacaoEntity = new Interacao
            {
                ChamadoId = id,
                Autor = interacao.Autor,
                Mensagem = interacao.Mensagem
            };
            await _interacoesRepository.Inserir(interacaoEntity);
        }
    }
}