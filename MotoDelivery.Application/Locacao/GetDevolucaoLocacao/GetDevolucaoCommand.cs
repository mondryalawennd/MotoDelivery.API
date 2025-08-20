using MediatR;
using MotoDelivery.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Application.Locacao.GetDevolucaoLocacao
{
    public class GetDevolucaoCommand: IRequest<GetDevolucaoLocacaoResult>
    {
        public string LocacaoId { get; set; } = string.Empty;
        public decimal ValorDiaria { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataDevolucao { get; set; }
    }
}
