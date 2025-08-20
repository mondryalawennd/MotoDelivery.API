using MediatR;

namespace MotoDelivery.Application.Locacao.GetLocacao
{
    public class GetLocacaoCommand : IRequest<GetLocacaoResult>
    {
        public string LocacaoId { get; set; } = string.Empty;

    }
}
