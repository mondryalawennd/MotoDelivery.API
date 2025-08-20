using AutoMapper;
using Locacao_ = MotoDelivery.Domain.Entities.Locacao;

namespace MotoDelivery.Application.Locacao.CreateLocacao
{
    public class CreateLocacaoProfile : Profile
    {
        public CreateLocacaoProfile()
        {
            CreateMap<Locacao_, CreateLocacaoResult>();
        }
    }
}
