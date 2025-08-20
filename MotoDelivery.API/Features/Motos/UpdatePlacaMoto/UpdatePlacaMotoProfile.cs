using AutoMapper;
using MotoDelivery.API.Features.Motos.UpdateMotos;
using MotoDelivery.Application.Moto.UpdateMoto;

namespace MotoDelivery.API.Features.Motos.UpdatePlacaMoto
{
    public class UpdatePlacaMotoProfile: Profile
    {
        public UpdatePlacaMotoProfile()
        {
            CreateMap<UpdatePlacaMotoRequest, UpdatePlacaMotoCommand>();

            CreateMap<UpdatePlacaMotoResult, UpdatePlacaMotoResponse>();
        }
    }
}
