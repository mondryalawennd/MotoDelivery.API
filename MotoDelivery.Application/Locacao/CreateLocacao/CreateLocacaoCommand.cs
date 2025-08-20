using MediatR;
using MotoDelivery.Domain.Enum;

namespace MotoDelivery.Application.Locacao.CreateLocacao
{
    public class CreateLocacaoCommand: IRequest<CreateLocacaoResult>
    {
        public Guid LocacaoId { get; set; }
        public string EntregadorId { get; set; } = string.Empty;
        public string MotoId { get; set; } = string.Empty;
        public decimal ValorDiaria { get; private set; }
        public decimal ValorTotal { get; private set; }
        public DateTime DataCriacao { get; private set; } = DateTime.UtcNow;
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public DateTime DataPrevisaoTermino { get; set; }
        public PlanoLocacao Plano { get; set; }
    }
}
