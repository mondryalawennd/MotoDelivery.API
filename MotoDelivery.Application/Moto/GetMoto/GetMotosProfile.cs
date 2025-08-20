using AutoMapper;
using Motos = MotoDelivery.Domain.Entities.Moto;



namespace MotoDelivery.Application.Moto.GetMoto
{
    public class GetMotosProfile : Profile
    {
        public GetMotosProfile()
        {
            CreateMap<Motos, GetMotoResult>();
        }
    }
}