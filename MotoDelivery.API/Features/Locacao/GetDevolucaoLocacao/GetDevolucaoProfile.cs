using AutoMapper;
using MotoDelivery.API.Features.Locacao.GetLocacao;
using MotoDelivery.Application.Locacao.GetDevolucaoLocacao;

namespace MotoDelivery.API.Features.Locacao.GetDevolucaoLocacao
{
    public class GetDevolucaoProfile: Profile
    {
        public GetDevolucaoProfile() {

            CreateMap<GetDevolucaoRequest, GetDevolucaoCommand>();
            CreateMap<GetDevolucaoLocacaoResult, GetDevolucaoResponse>()
            .ForMember(dest => dest.LocacaoId, opt => opt.MapFrom(src => src.LocacaoId))
            .ForMember(dest => dest.DataDevolucao, opt => opt.MapFrom(src => src.DataDevolucao))
            .ForMember(dest => dest.ValorTotal, opt => opt.MapFrom(src => src.ValorTotal));
        }

    }
}
