using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Application.Entregador.UploadCNH
{
    public class UploadCNHValidator: AbstractValidator<UploadCNHResult>
    {
        public UploadCNHValidator()
        {
            RuleFor(r => r.Identificador)
              .NotEmpty().WithMessage("O ID do entregador é obrigatório.");



        }
    }
}
