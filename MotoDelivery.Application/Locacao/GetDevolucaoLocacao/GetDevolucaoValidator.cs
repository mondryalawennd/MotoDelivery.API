using FluentValidation;
using MotoDelivery.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Application.Locacao.GetDevolucaoLocacao
{
    public class GetDevolucaoValidator: AbstractValidator<GetDevolucaoCommand>
    {
        public GetDevolucaoValidator()
        {
            RuleFor(x => x.DataDevolucao)
               .NotEmpty().WithMessage("A data de devolução é obrigatória.");

        }
    }
}
