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
            var chamado = await _chamadosService.ObterPorId(id);
            return Ok(chamado);
        }

        [HttpPost]
        public async Task<IActionResult> Inserir([FromBody] ChamadoCriarDto chamado)
        {
            await _chamadosService.Inserir(chamado);
            return Created("/chamados", chamado);
        }

        [HttpPost("{id}/iniciar")]
        public async Task<IActionResult> Iniciar([FromRoute] string id)
        {
            await _chamadosService.Iniciar(id);
            return Ok();
        }

        [HttpPost("{id}/encerrar")]
        public async Task<IActionResult> Encerrar([FromRoute] string id, [FromBody] ChamadoEncerrarDto chamado)
        {
            await _chamadosService.Encerrar(id, chamado);
            return Ok();
        }
    }

}