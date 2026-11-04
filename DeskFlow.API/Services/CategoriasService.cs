using DbApi.Exceptions;
using DeskFlow.API.Models.Entities;
using DeskFlow.API.Repositories.Interfaces;
using DeskFlow.API.Services.Interfaces;

namespace DeskFlow.API.Services
{
    public class CategoriasServices : ICategoriasService
    {
        private ICategoriasRepository _categoriasRepository;

        public CategoriasServices(ICategoriasRepository categoriasRepository)
        {
            _categoriasRepository = categoriasRepository;
        }
        public async Task<List<Categoria>> ObterTodos() => await _categoriasRepository.ObterTodos();
        public async Task<Categoria> ObterPorId(string id)
        {
            return await _categoriasRepository.ObterPorId(id);
        }
        public async Task Inserir(Categoria categoria)
        {
            await _categoriasRepository.Inserir(categoria);
        }
        public async Task Deletar(string id)
        {
            Categoria categoria = await _categoriasRepository.ObterPorId(id);

            if (categoria == null)
            {
                throw new NotFoundException("Categoria não encontrada.");

            }

            if (categoria.Chamados.Any())
            {
                throw new NotFoundException("Não é possível deletar uma categoria que possui chamados associados.");
            }

            await _categoriasRepository.Deletar(categoria);

        }
        public async Task Atualizar(Categoria categoria, string id)
        {
            Categoria categoriaExistente = await _categoriasRepository.ObterPorId(id);

            if (categoriaExistente == null)
            {
                throw new NotFoundException("Categoria não encontrada.");
            }

            categoriaExistente.Update(categoria);
            await _categoriasRepository.Atualizar(categoriaExistente);
        }
    }
}