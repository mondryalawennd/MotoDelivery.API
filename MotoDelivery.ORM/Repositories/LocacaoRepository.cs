
using Microsoft.EntityFrameworkCore;
using MotoDelivery.Domain.Entities;
using MotoDelivery.Domain.Repositories;
using MotoDelivery.ORM.Persistence;

namespace MotoDelivery.ORM.Repositories
{
    public class LocacaoRepository: ILocacaoRepository
    {
        private readonly AppDbContext _context;

        public LocacaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistsByMotoIdAsync(string motoId)
        {
            return await _context.Locacao.AnyAsync(l => l.MotoId == motoId);
        }

        public async Task<Locacao?> ObterPorIdAsync(string id)
        {
            return await _context.Locacao.FirstOrDefaultAsync(m => m.LocacaoId == id);
        }

        public async Task AddAsync(Locacao locacao)
        {
            _context.Locacao.Add(locacao);
            await _context.SaveChangesAsync();
        }
    }
}
