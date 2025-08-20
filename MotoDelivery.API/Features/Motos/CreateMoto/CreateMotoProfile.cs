using AutoMapper;
using MotoDelivery.Application.Moto.CreateMoto;

namespace MotoDelivery.API.Features.Motos.CreateMoto
{
    public class CreateMotoProfile : Profile
    {
        public CreateMotoProfile()
        {
            CreateMap<CreateMotoRequest, CreateMotoCommand>();

            CreateMap<CreateMotoResult, CreateMotoResponse>();
        }
    }
}
