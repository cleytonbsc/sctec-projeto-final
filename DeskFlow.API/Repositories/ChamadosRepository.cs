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
        public async Task<Chamado?> ObterPorId(string id)
        {
            return await _context.Chamados
            .Include(c => c.Categoria)
            .Include(c => c.Interacoes)
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

        public async Task<List<Chamado>> ObterTodos(string? status, string? categoria,string? categoriaID, string prioridade, DateTime? dataInicio, DateTime? dataFim)
        {
            var query = _context.Chamados
                .Include(c => c.Categoria)
                .Include(c => c.Interacoes)
                .AsQueryable();

            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(c => c.Status == status);
            }

            if (!string.IsNullOrEmpty(categoria))
            {
                query = query.Where(c => c.Categoria.Nome.Contains(categoria));
            }
            
            if (!string.IsNullOrEmpty(categoriaID))
            {
                query = query.Where(c => c.Categoria.Id == categoriaID);
            }

            if (!string.IsNullOrEmpty(prioridade))
            {
                query = query.Where(c => c.Prioridade == prioridade);
            }

            if (dataInicio.HasValue)
            {
                query = query.Where(c => c.DataAbertura >= dataInicio.Value);
            }

            if (dataFim.HasValue)
            {
                query = query.Where(c => c.DataAbertura <= dataFim.Value);
            }

            return await query.ToListAsync();   
        }
    }
}