using MotoDelivery.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Application.Locacao.GetLocacao
{
    public class GetLocacaoResult
    {
        public string LocacaoId { get; set; } = string.Empty;
        public string EntregadorId { get; set; } = string.Empty;
        public string MotoId { get; set; } = string.Empty;
        public decimal ValorDiaria { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public DateTime DataPrevisaoTermino { get; set; }
        public PlanoLocacao Plano { get; set; }
    }
}
