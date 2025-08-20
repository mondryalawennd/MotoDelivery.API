using MotoDelivery.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Domain.Services
{
    public interface IEventoService
    {
        Task PublishAsync<TEvent>(TEvent @event) where TEvent : class;
    }
}
