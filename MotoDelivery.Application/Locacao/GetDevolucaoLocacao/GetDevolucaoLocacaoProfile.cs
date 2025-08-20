using AutoMapper;
using MotoDelivery.Application.Locacao.CreateLocacao;
using Locacao_ = MotoDelivery.Domain.Entities.Locacao;

namespace MotoDelivery.Application.Locacao.GetDevolucaoLocacao
{
    public class GetDevolucaoLocacaoProfile: Profile
    {
        public GetDevolucaoLocacaoProfile()
        {
            CreateMap<Locacao_, GetDevolucaoLocacaoResult>()
                 .ForMember(dest => dest.LocacaoId, opt => opt.MapFrom(src => src.LocacaoId))
                .ForMember(dest => dest.DataDevolucao, opt => opt.MapFrom(src => src.DataPrevisaoTermino))
                .ForMember(dest => dest.ValorTotal, opt => opt.MapFrom(src => src.ValorDiaria));
        }
    }
}
