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

        public async Task<List<ChamadoDetalhesDto>> ObterTodos()
        {
            List<Chamado> chamados = await _chamadosRepository.ObterTodos();
            return chamados.Select(c => new ChamadoDetalhesDto(c)).ToList();
        }

        public async Task<ChamadoDetalhesDto> ObterPorId(string id)
        {
            var chamado = await _chamadosRepository.ObterPorId(id);
            if (chamado == null) return null;

            return new ChamadoDetalhesDto(chamado);
        }

        public async Task Inserir(ChamadoCriarDto chamado)
        {
            var chamadoEntity = new Chamado(chamado);
            await _chamadosRepository.Inserir(chamadoEntity);
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

        public async Task Encerrar(string id, ChamadoEncerrarDto chamado)
        {
            Chamado chamadoEncerrado = await _chamadosRepository.ObterPorId(id);

            if (chamadoEncerrado == null)
            {
               throw new NotFoundException("Chamado não encontrado.");
            }
            chamadoEncerrado.Status = StatusChamado.Fechado.ToString();
            chamadoEncerrado.Solucao = chamado.Solucao;
            chamadoEncerrado.DataFechamento = DateTime.Now;
            await _chamadosRepository.Encerrar(chamadoEncerrado);
        }
    }
}