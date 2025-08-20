using MotoDelivery.Domain.Enum;

namespace MotoDelivery.API.Features.Locacao.CreateLocacao
{
    public class CreateLocacaoResponse
    {
        public string LocacaoId { get; set; } = string.Empty;
        public string EntregadorId { get; set; } = string.Empty;
        public string MotoId { get; set; } = string.Empty;
        public decimal ValorDiaria { get; set; }
        public DateTime DataInicio { get; set; } = DateTime.UtcNow;
        public DateTime DataTermino { get; set; }
        public DateTime? DataPrevisaoTermino { get; set; }
        public PlanoLocacao Plano { get; set; }
    }
}
