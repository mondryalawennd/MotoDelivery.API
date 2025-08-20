using FluentValidation;

namespace MotoDelivery.API.Features.Entregador.CreateEntregador
{
    public class CreateEntregadorRequestValidator: AbstractValidator<CreateEntregadorRequest>
    {
        public CreateEntregadorRequestValidator() 
        {
            RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("O nome do entregador é obrigatório.")
            .MaximumLength(200).WithMessage("O nome do entregador deve ter no máximo 200 caracteres.");

            RuleFor(x => x.CNPJ)
                .NotEmpty().WithMessage("O CNPJ é obrigatório.")
                .Length(14).WithMessage("O CNPJ deve ter exatamente 14 dígitos.");

            RuleFor(x => x.TipoCNH)
                 .NotEmpty().WithMessage("O tipo de CNH é obrigatório.")
                 .Must(tipo => tipo == "A")
                 .WithMessage("O tipo de CNH deve ser 'A'.");

            RuleFor(x => x.NumeroCNH)
                .NotEmpty().WithMessage("O número da CNH é obrigatório.")
                .MaximumLength(20).WithMessage("O número da CNH deve ter no máximo 20 caracteres.");

        }
    }
}
