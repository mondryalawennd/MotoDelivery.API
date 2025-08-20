using AutoMapper;
using MotoDelivery.Application.Moto.GetMotos;

namespace MotoDelivery.API.Features.Motos.GetMotos
{
    public class GetMotosProfile : Profile
    {
        public GetMotosProfile()
        {
            CreateMap<GetMotosResult, GetMotosResponse>();
        }
    }
}
