using Microsoft.Extensions.Logging;
using MotoDelivery.Domain.Events;
using MotoDelivery.Domain.Repositories;
using MotoDelivery.Domain.Services;
using MotoDelivery.ORM.Persistence;
using Rebus.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.ORM.Services
{
    public class EventoService : IEventoService
    {
        private readonly ILogger<EventoService> _logger;

        public EventoService(ILogger<EventoService> logger)
        {
            _logger = logger;
        }

        public Task PublishAsync<TEvent>(TEvent @event) where TEvent : class
        {
            _logger.LogInformation($"Evento publicado: {typeof(TEvent).Name} -> {System.Text.Json.JsonSerializer.Serialize(@event)}");
            return Task.CompletedTask;
        }
    }
}
