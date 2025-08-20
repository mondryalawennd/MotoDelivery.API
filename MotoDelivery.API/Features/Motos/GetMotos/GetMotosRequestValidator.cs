using FluentValidation;

namespace MotoDelivery.API.Features.Motos.GetMotos
{
    public class GetMotosRequestValidator: AbstractValidator<GetMotosRequest>
    {
        public GetMotosRequestValidator()
        {
            RuleFor(x => x.Placa)
                .NotEmpty().WithMessage("Placa da moto é obrigatório.");
        }
    }
}
