using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Application.Moto.DeleteMotos
{
    public class DeleteMotoCommand : IRequest<DeleteMotoResult>
    {
        public string Identificador { get; set; } = string.Empty;
    }
}
