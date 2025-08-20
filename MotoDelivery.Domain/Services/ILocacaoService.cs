using MotoDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Domain.Services
{
    public interface ILocacaoService
    {
        decimal CalcularValorDevolucao(Locacao locacao, DateTime dataDevolucao);
    }
}
