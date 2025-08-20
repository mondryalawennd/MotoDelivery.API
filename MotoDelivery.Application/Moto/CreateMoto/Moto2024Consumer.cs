using MassTransit;
using MotoDelivery.Domain.Events;
using Motos = MotoDelivery.Domain.Entities.Moto;
using MotoDelivery.ORM.Persistence;
using MotoDelivery.Domain.Entities;

namespace MotoDelivery.Application.Moto.CreateMoto
{
    public class Moto2024Consumer : IConsumer<CreateMotoEvent>
    {
        private readonly AppDbContext _context;

        public Moto2024Consumer(AppDbContext context)
        {
            _context = context;
        }


        public async Task Consume(ConsumeContext<CreateMotoEvent> context)
        {
            var motoEvent = context.Message;

            if (motoEvent.Ano == 2024)
            {
                // Criar notificação
                var notification = new Notification
                {
                    MotoId = motoEvent.Identificador,
                    Message = $"Moto {motoEvent.Modelo} ({motoEvent.Placa}) cadastrada em 2024.",
                    CreatedAt = DateTime.UtcNow
                };

                _context.Notifications.Add(notification);
                await _context.SaveChangesAsync();
            }
        }
    }
}