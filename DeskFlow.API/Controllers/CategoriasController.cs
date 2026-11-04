using DeskFlow.API.Models.Entities;
using DeskFlow.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DeskFlow.API.Controllers
{
    [ApiController]
    [Route("api/categorias")]
    public class CategoriasController : ControllerBase
    {
        private ICategoriasService _categoriasService;

        public CategoriasController(ICategoriasService categoriasService)
        {
            _categoriasService = categoriasService;
        }

        [HttpPost]
        public async Task<IActionResult> Inserir([FromBody] Categoria categoria)
        {
            await _categoriasService.Inserir(categoria);
            return Created("/categorias", categoria);
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            List<Categoria> categorias = await _categoriasService.ObterTodos();
            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId([FromRoute]string id)
        {
            Categoria categoria = await _categoriasService.ObterPorId(id);
            return Ok(categoria);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar([FromRoute]string id)
        {
            await _categoriasService.Deletar(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar([FromBody] Categoria categoria, [FromRoute]string id)
        {
            await _categoriasService.Atualizar(categoria, id);
            return Ok();
        }   
    }
}