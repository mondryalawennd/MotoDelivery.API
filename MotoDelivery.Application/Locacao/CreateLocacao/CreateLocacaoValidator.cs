using FluentValidation;
using MotoDelivery.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Application.Locacao.CreateLocacao
{
    public class CreateLocacaoValidator : AbstractValidator<CreateLocacaoCommand>
    {
        public CreateLocacaoValidator()
        {
            RuleFor(l => l.DataInicio)
              .LessThan(l => l.DataTermino)
              .WithMessage("A data de início deve ser menor que a data de término.");

            RuleFor(l => l.DataTermino)
                .GreaterThan(l => l.DataInicio)
                .WithMessage("A data de término deve ser maior que a data de início.");

            RuleFor(x => x.DataInicio)
              .Must((command, dataInicio) => dataInicio.Date == command.DataCriacao.Date.AddDays(1))
              .WithMessage("A data de início deve ser o primeiro dia após a data de criação.");

            RuleFor(x => x.DataTermino)
                 .Must((request, dataTermino) =>
                 {
                     int diasPlano = (int)request.Plano; 
                     int diasInformados = (dataTermino - request.DataInicio).Days;
                     return diasInformados == diasPlano;
                 })
                 .WithMessage("O período informado não corresponde ao plano selecionado.");

        }
    }
}