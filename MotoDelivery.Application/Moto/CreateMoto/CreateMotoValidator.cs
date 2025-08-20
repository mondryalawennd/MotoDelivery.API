using FluentValidation;
using MotoDelivery.Domain.Repositories;
using System.Threading.Tasks;

namespace MotoDelivery.Application.Moto.CreateMoto
{
    public class CreateMotoValidator : AbstractValidator<CreateMotoCommand>
    {
        public CreateMotoValidator(IMotoRepository repository)
        {
            RuleFor(x => x.Ano)
                .InclusiveBetween(1900, DateTime.Now.Year + 1)
                .WithMessage("Ano inválido");

            RuleFor(x => x.Placa)
                .Matches(@"^[A-Z]{3}-\d{4}$").WithMessage("Placa inválida");
        }
    }
}
