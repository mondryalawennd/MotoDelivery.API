using FluentValidation;

namespace MotoDelivery.API.Features.Motos.CreateMoto
{
    public class CreateMotoRequestValidator : AbstractValidator<CreateMotoRequest>
    {
        public CreateMotoRequestValidator()
        {
            RuleFor(x => x.Identificador)
               .NotEmpty().WithMessage("Identificador é obrigatório");

            RuleFor(x => x.Modelo)
                 .NotEmpty().WithMessage("O modelo é obrigatório")
                 .MaximumLength(50);

            RuleFor(x => x.Placa)
                  .NotEmpty().WithMessage("Placa é obrigatório");

            RuleFor(x => x.Ano)
                 .NotEmpty().WithMessage("Ano é obrigatório");
        }
    }
}
