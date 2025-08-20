using AutoMapper;
using MotoDelivery.Application.Locacao.CreateLocacao;
using Locacao_ = MotoDelivery.Domain.Entities.Locacao;

namespace MotoDelivery.Application.Locacao.GetLocacao
{
    public class GetLocacaoProfile: Profile
    {
        public GetLocacaoProfile()
        {
            CreateMap<Locacao_, GetLocacaoResult>()
                .ForMember(dest => dest.LocacaoId, opt => opt.MapFrom(src => src.LocacaoId))
                .ForMember(dest => dest.EntregadorId, opt => opt.MapFrom(src => src.EntregadorId))
                .ForMember(dest => dest.MotoId, opt => opt.MapFrom(src => src.MotoId))
                .ForMember(dest => dest.ValorDiaria, opt => opt.MapFrom(src => src.ValorDiaria))
                .ForMember(dest => dest.DataInicio, opt => opt.MapFrom(src => src.DataInicio))
                .ForMember(dest => dest.DataTermino, opt => opt.MapFrom(src => src.DataTermino))
                .ForMember(dest => dest.DataPrevisaoTermino, opt => opt.MapFrom(src => src.DataPrevisaoTermino))
                .ForMember(dest => dest.Plano, opt => opt.MapFrom(src => src.Plano));


        }
    }
}
