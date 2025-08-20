using FluentValidation;
using MotoDelivery.Domain.Enum;

namespace MotoDelivery.API.Features.Locacao.CreateLocacao
{
    public class CreateLocacaoRequestValidator: AbstractValidator<CreateLocacaoRequest>
    {
        public CreateLocacaoRequestValidator()
        {
            RuleFor(l => l.EntregadorId)
               .NotEmpty().WithMessage("O entregador é obrigatório.")
               .MaximumLength(36).WithMessage("O identificador do entregador deve ter no máximo 36 caracteres.");

            RuleFor(l => l.MotoId)
                .NotEmpty().WithMessage("A moto é obrigatória.")
                .MaximumLength(36).WithMessage("O identificador da moto deve ter no máximo 36 caracteres.");

            RuleFor(x => x.DataInicio)
               .NotEmpty().WithMessage("A data de início é obrigatória.");

            RuleFor(x => x.DataTermino)
                .NotEmpty().WithMessage("A data de término é obrigatória.");

            RuleFor(x => x.DataPrevisaoTermino)
             .NotEmpty().WithMessage("A data de previsão de término é obrigatória.");

            RuleFor(x => x.Plano.ObterDias())
               .InclusiveBetween(7, 50)
               .WithMessage("O plano deve ser válido: 7, 15, 30, 45 ou 50 dias.");

            RuleFor(l => l.DataTermino)
               .GreaterThan(l => l.DataInicio)
               .WithMessage("A data de término deve ser maior que a data de início.");


        }
    }
}
