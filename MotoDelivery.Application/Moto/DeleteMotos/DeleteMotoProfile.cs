using AutoMapper;
using Motos = MotoDelivery.Domain.Entities.Moto;

namespace MotoDelivery.Application.Moto.DeleteMotos
{
    public class DeleteMotoProfile : Profile
    {
        public DeleteMotoProfile()
        {
            CreateMap<Motos, DeleteMotoResult>();
        }
    }
}
