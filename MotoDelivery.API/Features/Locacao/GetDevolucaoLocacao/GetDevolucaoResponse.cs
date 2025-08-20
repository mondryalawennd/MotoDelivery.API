namespace MotoDelivery.API.Features.Locacao.GetDevolucaoLocacao
{
    public class GetDevolucaoResponse
    {
        public string LocacaoId { get; set; } = string.Empty;
        public decimal ValorTotal { get; set; }
        public DateTime DataDevolucao { get; set; }
    }
}
