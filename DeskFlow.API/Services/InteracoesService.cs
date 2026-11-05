using DeskFlow.API.Models.Dtos;
using DeskFlow.API.Models.Entities;
using DeskFlow.API.Repositories.Interfaces;
using DeskFlow.API.Services.Interfaces;

namespace DeskFlow.API.Services
{
    public class InteracoesService : IInteracoesService
    {
        private readonly IInteracoesRepository _interacoesRepository;

        private readonly IChamadosRepository _ChamadosRepository;

        public InteracoesService(IInteracoesRepository interacoesRepository, IChamadosRepository chamadosRepository)
        {
            _interacoesRepository = interacoesRepository;
            _ChamadosRepository = chamadosRepository;
        }

        public async Task<List<Interacao>> ObterPorChamadoId(string chamadoId)
        {
            return await _interacoesRepository.ObterPorChamadoId(chamadoId);
        }

        public async Task Inserir(String id, InteracaoCriarDto interacao)
        {
            Chamado chamado = await _ChamadosRepository.ObterPorId(id);
            if (chamado == null) 
            {
                throw new KeyNotFoundException($"O chamado com o ID {id} não existe.");
            }
            if (chamado.Status == "Fechado")
            {
                throw new InvalidOperationException("Não é possível adicionar interações em um chamado fechado.");
            }
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