using MotoDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Domain.Repositories
{
    public interface IMotoRepository
    {
        Task AddAsync(Moto moto);
        Task<Moto?> ObterPorIdAsync(string id);
        Task<bool> ExistsPlacaAsync(string placa, string? idExcluir = null);
        Task<bool> ExistsByIdAsync(string id);
        Task<List<Moto>> GetMotosAsync(string? placa = null);
        Task UpdateAsync(Moto moto);
        Task DeleteAsync(Moto moto);
    }
}