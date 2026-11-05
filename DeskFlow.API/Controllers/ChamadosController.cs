using DeskFlow.API.Models.Dtos;
using DeskFlow.API.Models.Entities;
using DeskFlow.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DeskFlow.API.Controllers
{
    [ApiController]
    [Route("api/chamados")]
    public class ChamadosController : ControllerBase
    {
        private IChamadosService _chamadosService;

        private IInteracoesService _InteracoesService;

        public ChamadosController(IChamadosService chamadosService, IInteracoesService InteracoesService)
        {
            _chamadosService = chamadosService;
            _InteracoesService = InteracoesService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var chamados = await _chamadosService.ObterTodos();
            return Ok(chamados);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId([FromRoute] string id)
        {
            ChamadoDetalhesDto? chamado = await _chamadosService.ObterPorId(id);
            if (chamado == null) return NotFound(new { mensagem = $"Não encontramos o chamado com o ID {id}." });
            return Ok(chamado);
        }

        [HttpPost]
        public async Task<IActionResult> Inserir([FromBody] ChamadoCriarDto chamado)
        {
            var chamadoDetalhes = await _chamadosService.Inserir(chamado);
            return Created("/chamados", chamadoDetalhes);
        }

        [HttpPost("{id}/iniciar")]
        public async Task<IActionResult> Iniciar([FromRoute] string id)
        {
            ChamadoDetalhesDto? chamado = await _chamadosService.ObterPorId(id);
            if (chamado == null) return NotFound(new { mensagem = $"Não encontramos o chamado com o ID {id}." });
            await _chamadosService.Iniciar(id);
            return Ok(new { mensagem = "Chamado iniciado com sucesso!", chamado.Id });
        }

        [HttpPost("{id}/encerrar")]
        public async Task<IActionResult> Encerrar([FromRoute] string id, [FromBody] ChamadoEncerrarDto chamado)
        {
            ChamadoDetalhesDto? chamadoDetalhes = await _chamadosService.ObterPorId(id);
            if (chamadoDetalhes == null) return NotFound(new { mensagem = $"Não encontramos o chamado com o ID {id}." });
            await _chamadosService.Encerrar(id, chamado);
            return Ok(new { mensagem = "Chamado encerrado com sucesso!", chamadoDetalhes.Id });
        }

        [HttpGet("{id}/interacoes")]
        public async Task<IActionResult> ObterInteracoes([FromRoute] string id)
        {
            var interacoes = await _InteracoesService.ObterPorChamadoId(id);
            return Ok(interacoes);
        }

        [HttpPost("{id}/interacoes")]
        public async Task<IActionResult> InserirInteracao([FromRoute] string id, [FromBody] InteracaoCriarDto interacao)
        {
            try
            {
                await _InteracoesService.Inserir(id, interacao);
                return Created($"/api/chamados/{id}/interacoes", new { mensagem = "Interação adicionada com sucesso!" });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }

}