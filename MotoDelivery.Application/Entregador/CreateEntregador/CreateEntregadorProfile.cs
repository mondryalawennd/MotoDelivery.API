using AutoMapper;
using Entregador_ = MotoDelivery.Domain.Entities.Entregador;

namespace MotoDelivery.Application.Entregador.CreateEntregador
{
    public class CreateEntregadorProfile : Profile
    {
        public CreateEntregadorProfile()
        {
            CreateMap<Entregador_, CreateEntregadorResult>();
        }
    }
}
