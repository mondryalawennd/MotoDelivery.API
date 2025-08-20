using AutoMapper;
using Motos = MotoDelivery.Domain.Entities.Moto;

namespace MotoDelivery.Application.Moto.UpdateMoto
{
    public class AlterarMotoProfile : Profile
    {
        public AlterarMotoProfile()
        {
            CreateMap<Motos, UpdatePlacaMotoResult>();
        }
    }
}
