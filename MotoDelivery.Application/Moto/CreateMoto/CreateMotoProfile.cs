using AutoMapper;
using Motos = MotoDelivery.Domain.Entities.Moto;


namespace MotoDelivery.Application.Moto.CreateMoto
{
    public class CreateMotoProfile : Profile
    {
        public CreateMotoProfile()
        {
            CreateMap<Motos, CreateMotoResult>();

        }
    }
}
