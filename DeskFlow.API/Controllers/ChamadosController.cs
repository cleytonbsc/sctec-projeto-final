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
        public async Task<IActionResult> Inserir([FromBody] Chamado chamado)
        {
            await _chamadosService.Inserir(chamado);
            return Created("/chamados", new ChamadoDetalhesDto(chamado));
        }

    }

}