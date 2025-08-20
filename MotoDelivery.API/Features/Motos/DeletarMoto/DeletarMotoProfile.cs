using AutoMapper;
using MotoDelivery.Application.Moto.DeleteMotos;

namespace MotoDelivery.API.Features.Motos.DeletarMoto
{
    public class DeletarMotoProfile : Profile
    {
        public DeletarMotoProfile()
        {
            CreateMap<DeletarMotoRequest, DeleteMotoCommand>();
            CreateMap<DeleteMotoCommand, DeletarMotoResponse>();
            CreateMap<DeleteMotoResult, DeletarMotoResponse>();
        }
    }
}
