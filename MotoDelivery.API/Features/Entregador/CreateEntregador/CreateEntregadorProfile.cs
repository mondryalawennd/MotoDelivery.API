using AutoMapper;
using MotoDelivery.Application.Locacao.CreateLocacao;

namespace MotoDelivery.API.Features.Entregador.CreateEntregador
{
    public class CreateEntregadorProfile : Profile
    {
        public CreateEntregadorProfile()
        {
            CreateMap<CreateEntregadorRequest, CreateLocacaoCommand>();
        }
    }
}
