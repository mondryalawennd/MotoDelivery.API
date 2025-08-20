using FluentValidation;

namespace MotoDelivery.API.Features.Locacao.GetLocacao
{
    public class GetLocacaoRequestValidator: AbstractValidator<GetLocacaoRequest>
    {
        public GetLocacaoRequestValidator()
        {
            RuleFor(x => x.LocacaoId).NotEmpty();
        }
    }
}
