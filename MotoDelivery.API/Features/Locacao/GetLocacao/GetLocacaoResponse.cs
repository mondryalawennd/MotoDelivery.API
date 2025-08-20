namespace MotoDelivery.API.Features.Locacao.GetLocacao
{
    public class GetLocacaoResponse
    {
        public string LocacaoId { get; set; } = string.Empty;
        public string EntregadorId { get; set; } = string.Empty;
        public string MotoId { get; set; } = string.Empty;
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public DateTime DataPrevisaoTermino { get; set; }
        public decimal ValorDiaria { get; set; }
    }
}
