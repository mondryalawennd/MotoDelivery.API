using MotoDelivery.Domain.Entities;
using MotoDelivery.Domain.Enum;
using MotoDelivery.Domain.Services;

namespace MotoDelivery.ORM.Services
{
    public class LocacaoService : ILocacaoService
    {
        public decimal CalcularValorDevolucao(Locacao locacao, DateTime dataDevolucao)
        {
            var diasContratados = locacao.Plano.ObterDias();
            var valorDiaria = locacao.Plano.ObterValorDiaria();
            var valorBase = diasContratados * valorDiaria;

            // devolução antes do prazo
            if (dataDevolucao < locacao.DataPrevisaoTermino)
            {
                int diasUsados = (dataDevolucao - locacao.DataInicio).Days;
                int diasNaoUsados = diasContratados - diasUsados;

                decimal valorUsado = diasUsados * valorDiaria;
                decimal multa = locacao.Plano switch
                {
                    PlanoLocacao.SeteDias => diasNaoUsados * valorDiaria * 0.20m,
                    PlanoLocacao.QuinzeDias => diasNaoUsados * valorDiaria * 0.40m,
                    _ => 0m
                };

                return valorUsado + multa;
            }

            // devolução no prazo exato
            if (dataDevolucao == locacao.DataPrevisaoTermino)
            {
                return valorBase;
            }

            // devolução após prazo
            if (dataDevolucao > locacao.DataPrevisaoTermino)
            {
                int diasAdicionais = (dataDevolucao - locacao.DataPrevisaoTermino).Days;
                decimal adicional = diasAdicionais * 50m;

                return valorBase + adicional;
            }

            return valorBase;
        }       
    }
}
