using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Application.Entregador.CreateEntregador
{
    public class CreateEntregadorValidator : AbstractValidator<CreateEntregadorCommand>
    {
        public CreateEntregadorValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("Nome é obrigatório");
            RuleFor(x => x.CNPJ).NotEmpty().WithMessage("CNPJ é obrigatório");
            RuleFor(x => x.DataNascimento).LessThan(DateTime.Today).WithMessage("Data de nascimento inválida");
            RuleFor(x => x.NumeroCNH).NotEmpty().WithMessage("Número da CNH é obrigatório");
        }
    }
}