using FluentValidation;
using MotoDelivery.API.Features.Motos.UpdateMotos;

namespace MotoDelivery.API.Features.Motos.UpdatePlacaMoto
{
    public class UpdatePlacaMotoRequestValidator: AbstractValidator<UpdatePlacaMotoRequest>
    {
        public UpdatePlacaMotoRequestValidator()
        {
            RuleFor(x => x.Identificador)
                .NotEmpty().WithMessage("O Identificador da moto é obrigatório");

            RuleFor(x => x.Placa)
                .NotEmpty().WithMessage("A placa é obrigatória")
                .Matches(@"^[A-Z]{3}-\d{4}$").WithMessage("A placa deve estar no formato AAA-0000");
        }
    }
}
