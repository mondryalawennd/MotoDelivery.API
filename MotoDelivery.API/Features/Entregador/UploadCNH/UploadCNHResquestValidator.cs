using FluentValidation;

namespace MotoDelivery.API.Features.Entregador.UploadCNH
{
    public class UploadCNHResquestValidator: AbstractValidator<UploadCNHRequest>
    {
        public UploadCNHResquestValidator()
        {
            RuleFor(r => r.Identificador)
                .NotEmpty().WithMessage("O ID do entregador é obrigatório.");

            RuleFor(x => x.ImagemCNH)
                 .NotNull().WithMessage("O arquivo da CNH é obrigatório.")
                 .Must(f => f != null && (f.ContentType == "image/png" || f.ContentType == "image/bmp"))
                 .WithMessage("A CNH deve estar no formato PNG ou BMP.");
        }
    }
}
