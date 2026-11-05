using DeskFlow.API.Data;
using DeskFlow.API.Models.Entities;
using DeskFlow.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DeskFlow.API.Repositories
{
    public class InteracoesRepository : IInteracoesRepository
    {
        private AppDbContext _context;

        public InteracoesRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Interacao>> ObterPorChamadoId(string chamadoId)
        {
            return await _context.Interacoes.Where(i => i.ChamadoId == chamadoId).ToListAsync();
        }

        public async Task Inserir(Interacao interacao)
        {
            await _context.Interacoes.AddAsync(interacao);
            await _context.SaveChangesAsync();
        }
    }
}