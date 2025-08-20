namespace MotoDelivery.API.Features.Locacao.GetDevolucaoLocacao
{
    public class GetDevolucaoRequest
    {
        public string LocacaoId { get; set; } = string.Empty;
        public string DataDevolucao { get; set; } = string.Empty;
    }
}
