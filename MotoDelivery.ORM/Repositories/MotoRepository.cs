using Microsoft.EntityFrameworkCore;
using MotoDelivery.Domain.Entities;
using MotoDelivery.Domain.Repositories;
using MotoDelivery.ORM.Persistence;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Threading;

namespace MotoDelivery.ORM.Repositories
{
    public class MotoRepository : IMotoRepository
    {
        private readonly AppDbContext _context;

        public MotoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistsPlacaAsync(string placa, string? idExcluir = null)
        {
            var query = _context.Motos.AsQueryable();

            if (!string.IsNullOrEmpty(idExcluir))
                query = query.Where(m => m.Identificador != idExcluir);

            return await query.AnyAsync(m => m.Placa == placa);
        }

        public async Task AddAsync(Moto moto)
        {
            _context.Motos.Add(moto);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsByIdAsync(string id)
        {
            return await _context.Motos.AnyAsync(m => m.Identificador == id);
        }

        public async Task<List<Moto>> GetMotosAsync(string? placa = null)
        {
            var query = _context.Motos.AsQueryable();
            if (!string.IsNullOrEmpty(placa))
                query = query.Where(m => m.Placa == placa);

            return await query.ToListAsync();
        }

        public async Task<Moto?> ObterPorIdAsync(string id)
        {
            return await _context.Motos.FirstOrDefaultAsync(m => m.Identificador == id);
        }

        public async Task UpdateAsync(Moto moto)
        {
            _context.Motos.Update(moto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Moto moto)
        {
            _context.Motos.Remove(moto);
            await _context.SaveChangesAsync();
        }
    }
}