using DeskFlow.API.Data;
using DeskFlow.API.Models.Entities;
using DeskFlow.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DeskFlow.API.Repositories
{
    public class ChamadosRepository : IChamadosRepository
    {
        private AppDbContext _context;

        public ChamadosRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Chamado>> ObterTodos()
        {
            return await _context.Chamados.Include(c => c.Categoria).ToListAsync();
        }

        public async Task<Chamado> ObterPorId(string id)
        {
            return await _context.Chamados
            .Include(c => c.Categoria)
            .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task Inserir(Chamado chamado)
        {
            await _context.Chamados.AddAsync(chamado);
            await _context.SaveChangesAsync();
            await _context.Entry(chamado).Reference(c => c.Categoria).LoadAsync();
        }

        public async Task Iniciar(Chamado chamado)
        {
            _context.Chamados.Update(chamado);
            await _context.SaveChangesAsync();
        }

        public async Task Encerrar(Chamado chamado)
        {
            _context.Chamados.Update(chamado);
            await _context.SaveChangesAsync();
        }
    }
}