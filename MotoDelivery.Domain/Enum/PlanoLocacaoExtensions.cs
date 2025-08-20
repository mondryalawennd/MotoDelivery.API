using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Domain.Enum
{
    public static class PlanoLocacaoExtensions
    {
        public static int ObterDias(this PlanoLocacao plano) => plano switch
        {
            PlanoLocacao.SeteDias => 7,
            PlanoLocacao.QuinzeDias => 15,
            PlanoLocacao.TrintaDias => 30,
            PlanoLocacao.QuarentaECincoDias => 45,
            PlanoLocacao.CinquentaDias => 50,
            _ => throw new ArgumentOutOfRangeException(nameof(plano))
        };

        public static decimal ObterValorDiaria(this PlanoLocacao plano) => plano switch
        {
            PlanoLocacao.SeteDias => 30m,
            PlanoLocacao.QuinzeDias => 28m,
            PlanoLocacao.TrintaDias => 22m,
            PlanoLocacao.QuarentaECincoDias => 20m,
            PlanoLocacao.CinquentaDias => 18m,
            _ => throw new ArgumentOutOfRangeException(nameof(plano))
        };
    }
}
