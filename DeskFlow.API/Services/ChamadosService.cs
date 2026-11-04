using DbApi.Exceptions;
using DeskFlow.API.Models.Dtos;
using DeskFlow.API.Models.Entities;
using DeskFlow.API.Models.Enums;
using DeskFlow.API.Repositories.Interfaces;
using DeskFlow.API.Services.Interfaces;

namespace DeskFlow.API.Services
{
    public class ChamadosService : IChamadosService
    {
        private IChamadosRepository _chamadosRepository;

        public ChamadosService(IChamadosRepository chamadosRepository)
        {
            _chamadosRepository = chamadosRepository;
        }

        public async Task<List<Chamado>> ObterTodos() => await _chamadosRepository.ObterTodos();

        public async Task<ChamadoDetalhesDto> ObterPorId(string id)
        {
            var chamado = await _chamadosRepository.ObterPorId(id);
            if (chamado == null) return null;

            return new ChamadoDetalhesDto(chamado);
        }

        public async Task Inserir(Chamado chamado)
        {
            await _chamadosRepository.Inserir(chamado);
        }

        public async Task Iniciar(string id)
        {
            Chamado chamado = await _chamadosRepository.ObterPorId(id);

            if (chamado == null)
            {
               throw new NotFoundException("Chamado não encontrado.");
            }
            chamado.Status = StatusChamado.EmAndamento.ToString();
            await _chamadosRepository.Iniciar(chamado);
        }

        public async Task Encerrar(string id)
        {
            Chamado chamado = await _chamadosRepository.ObterPorId(id);

            if (chamado == null)
            {
               throw new NotFoundException("Chamado não encontrado.");
            }
            chamado.Status = StatusChamado.Fechado.ToString();
            await _chamadosRepository.Encerrar(chamado);
        }
    }
}