using DeskFlow.API.Data;
using DeskFlow.API.Models.Entities;
using DeskFlow.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DeskFlow.API.Repositories
{
    public class CategoriasRepository : ICategoriasRepository
    {
        private AppDbContext _context;

        public CategoriasRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Categoria>> ObterTodos()
        {
            return await _context.Categorias.ToListAsync();
        }

        public async Task<Categoria> ObterPorId(string id)
        {
            return await _context.Categorias.FindAsync(id);
        }

        public async Task Inserir(Categoria categoria)
        {
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task Deletar(Categoria categoria)
        {
            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            await _context.SaveChangesAsync();
        }
    }
}