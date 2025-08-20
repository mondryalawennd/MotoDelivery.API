

namespace MotoDelivery.Application.Locacao.GetDevolucaoLocacao
{
    public class GetDevolucaoLocacaoResult
    {
        public string LocacaoId { get; set; } = string.Empty;
        public decimal ValorTotal { get; set; }
        public DateTime DataDevolucao { get; set; }
    }
}
