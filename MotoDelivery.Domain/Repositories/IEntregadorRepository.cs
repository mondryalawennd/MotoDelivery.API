using MotoDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Domain.Repositories
{
    public interface IEntregadorRepository
    {
        Task<Entregador?> ObterPorIdAsync(string id);
        Task AddAsync(Entregador entregador);
        Task<bool> ExistsByCnpjAsync(string cnpj);
        Task<bool> ExistsByCnhAsync(string numeroCnh);

        Task UpdateAsync(Entregador entregador);
    }
}