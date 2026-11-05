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

        public ChamadosController(IChamadosService chamadosService)
        {
            _chamadosService = chamadosService;
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


    }

}