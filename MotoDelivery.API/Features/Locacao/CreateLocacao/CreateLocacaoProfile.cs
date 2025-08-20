using AutoMapper;
using MotoDelivery.API.Features.Entregador.CreateEntregador;
using MotoDelivery.Application.Entregador.CreateEntregador;
using MotoDelivery.Application.Locacao.CreateLocacao;

namespace MotoDelivery.API.Features.Locacao.CreateLocacao
{
    public class CreateLocacaoProfile : Profile
    {
        public  CreateLocacaoProfile()
        {
            CreateMap<CreateEntregadorRequest, CreateEntregadorCommand>();
            CreateMap<CreateEntregadorCommand, CreateEntregadorResponse>();

            CreateMap<CreateEntregadorResult, CreateEntregadorResponse>();

            CreateMap<CreateLocacaoRequest, CreateLocacaoCommand>();
            CreateMap<CreateLocacaoCommand, CreateLocacaoResponse>();

            CreateMap<CreateLocacaoResult, CreateLocacaoResponse>();
            CreateMap<CreateLocacaoRequest, CreateLocacaoCommand>();
        }
    }
}
