using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Application.Entregador.CreateEntregador
{
    public class CreateEntregadorCommand : IRequest<CreateEntregadorResult>
    {
        public string Identificador { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string CNPJ { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public string NumeroCNH { get; set; } = string.Empty;
        public string TipoCNH { get; set; } = string.Empty;
        public string ImagemCNHUrl { get; set; } = string.Empty;
    }
}