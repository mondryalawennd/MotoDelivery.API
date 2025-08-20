using MotoDelivery.Domain.Enum;


namespace MotoDelivery.Domain.Entities
{
    public class Locacao
    {
        public string LocacaoId { get; set; } = string.Empty;
        public string EntregadorId { get; set; } = string.Empty;
        public string MotoId { get; set; } = string.Empty;   
        public decimal ValorDiaria { get; set; } 
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public DateTime DataPrevisaoTermino { get; set; }
        public PlanoLocacao Plano { get; set; }

        private Locacao() { } // EF Core

        public Locacao(string entregadorId, string motoId, PlanoLocacao plano, DateTime dataInicio, DateTime dataTermino, DateTime dataPrevisaoTermino)
        {
            LocacaoId = Guid.NewGuid().ToString();
            EntregadorId = entregadorId;
            MotoId = motoId;
            Plano = plano;
            DataInicio = dataInicio;
            DataTermino = dataTermino;
            DataPrevisaoTermino = dataPrevisaoTermino;
            ValorDiaria = CalcularValor((PlanoLocacao)plano);
        }

        private decimal CalcularValor(PlanoLocacao plano)
        {
            return plano switch
            {
                PlanoLocacao.SeteDias => 7 * 30m,
                PlanoLocacao.QuinzeDias => 15 * 28m,
                PlanoLocacao.TrintaDias => 30 * 22m,
                PlanoLocacao.QuarentaECincoDias => 45 * 20m,
                PlanoLocacao.CinquentaDias => 50 * 18m,
                _ => 0.0m
            };
        }
    }
}