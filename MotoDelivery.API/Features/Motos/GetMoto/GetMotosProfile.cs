using AutoMapper;
using MotoDelivery.Application.Moto.GetMoto;
using MotoDelivery.Application.Moto.GetMotos;

namespace MotoDelivery.API.Features.Motos.GetMoto
{
    public class GetMotosProfile : Profile
    {
        public GetMotosProfile()
        {
            CreateMap<GetMotoResult, GetMotoResponse>();
        }
    }
}
