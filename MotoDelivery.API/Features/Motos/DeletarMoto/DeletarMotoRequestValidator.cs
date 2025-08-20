using FluentValidation;

namespace MotoDelivery.API.Features.Motos.DeletarMoto
{
    public class DeletarMotoRequestValidator: AbstractValidator<DeletarMotoRequest>
    {
        public DeletarMotoRequestValidator()
        {
            RuleFor(x => x.Identificador)
                .NotEmpty().WithMessage("O identificador da moto é obrigatório.");
        }
    }
}
