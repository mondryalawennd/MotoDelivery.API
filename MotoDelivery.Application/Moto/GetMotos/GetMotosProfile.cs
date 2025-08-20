using AutoMapper;
using Motos = MotoDelivery.Domain.Entities.Moto;



namespace MotoDelivery.Application.Moto.GetMotos
{
    public class GetMotosProfile : Profile
    {
        public GetMotosProfile()
        {
            CreateMap<Motos, GetMotosResult>();
        }
    }
}