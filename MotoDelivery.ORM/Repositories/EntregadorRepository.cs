using Microsoft.EntityFrameworkCore;
using MotoDelivery.Domain.Entities;
using MotoDelivery.Domain.Repositories;
using MotoDelivery.ORM.Persistence;

namespace MotoDelivery.ORM.Repositories
{
    public class EntregadorRepository : IEntregadorRepository
    {
        private readonly AppDbContext _context;

        public EntregadorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Entregador?> ObterPorIdAsync(string id)
        {
            return await _context.Entregador.FirstOrDefaultAsync(m => m.Identificador == id);
        }

        public async Task AddAsync(Entregador entregador)
        {
            _context.Entregador.Add(entregador);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsByCnpjAsync(string cnpj)
        {
            return await _context.Entregador.AnyAsync(e => e.CNPJ == cnpj);
        }

        public async Task<bool> ExistsByCnhAsync(string numeroCnh)
        {
            return await _context.Entregador.AnyAsync(e => e.NumeroCNH == numeroCnh);
        }

        public async Task UpdateAsync(Entregador entregador)
        {
            _context.Entregador.Update(entregador);
            await _context.SaveChangesAsync();
        }
    }
}