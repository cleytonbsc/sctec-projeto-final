using DbApi.Exceptions;
using DeskFlow.API.Models.Dtos;
using DeskFlow.API.Models.Entities;
using DeskFlow.API.Repositories.Interfaces;
using DeskFlow.API.Services.Interfaces;

namespace DeskFlow.API.Services
{
    public class CategoriasServices : ICategoriasService
    {
        private readonly ICategoriasRepository _categoriasRepository;

        public CategoriasServices(ICategoriasRepository categoriasRepository)
        {
            _categoriasRepository = categoriasRepository;
        }
        public async Task<List<CategoriasDetalhesDto>> ObterTodos()
        {
            List<Categoria> categorias = await _categoriasRepository.ObterTodos();

            return categorias.Select(c => new CategoriasDetalhesDto
            {
                Id = c.Id,
                Nome = c.Nome
            }).ToList();
        }
        public async Task<CategoriasDetalhesDto> ObterPorId(string id)
        {
            Categoria? categoria = await _categoriasRepository.ObterPorId(id);
            
            if (categoria == null)
            {
                throw new NotFoundException("Categoria não encontrada.");

            }

            CategoriasDetalhesDto categoriaDetalhes = new CategoriasDetalhesDto
            {
                Id = categoria.Id,
                Nome = categoria.Nome
            };
            return categoriaDetalhes;
        }
        public async Task Inserir(CategoriasDto categoria)
        {
            Categoria categoriaEntity = new Categoria
            {
                Nome = categoria.Nome
            };
            await _categoriasRepository.Inserir(categoriaEntity);
        }
        public async Task Deletar(string id)
        {
            Categoria? categoria = await _categoriasRepository.ObterPorId(id);

            if (categoria == null)
            {
                throw new NotFoundException("Categoria não encontrada.");

            }

            if (categoria.Chamados != null && categoria.Chamados.Any())
            {
                throw new NotFoundException("Não é possível deletar uma categoria que possui chamados associados.");
            }

            await _categoriasRepository.Deletar(categoria);

        }
        public async Task Atualizar(CategoriasDto categoria, string id)
        {
            Categoria? categoriaExistente = await _categoriasRepository.ObterPorId(id);

            if (categoriaExistente == null)
            {
                throw new NotFoundException("Categoria não encontrada.");
            }

            Categoria categoriaEntity = new Categoria
            {
                Nome = categoria.Nome
            };
            categoriaExistente.Update(categoriaEntity);
            await _categoriasRepository.Atualizar(categoriaExistente);
        }
    }
}