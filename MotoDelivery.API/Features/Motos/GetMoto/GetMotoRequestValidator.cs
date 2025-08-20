using FluentValidation;
using MotoDelivery.API.Features.Motos.GetMotos;

namespace MotoDelivery.API.Features.Motos.GetMoto
{
    public class GetMotoRequestValidator : AbstractValidator<GetMotoRequest>
    {
        public GetMotoRequestValidator()
        {
            RuleFor(x => x.Identificador)
                .NotEmpty().WithMessage("O identificador da moto é obrigatório.");
        }
    }
}
