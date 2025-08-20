using MotoDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Domain.Events
{
    public record CreateMotoEvent(
        string Identificador,
        int Ano,
        string Modelo,
        string Placa
    );

}

