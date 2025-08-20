using AutoMapper;
using MotoDelivery.Application.Entregador.UploadCNH;

namespace MotoDelivery.API.Features.Entregador.UploadCNH
{
    public class UploadCNHProfile: Profile
    {
        public UploadCNHProfile()
        {
            CreateMap<UploadCNHRequest, UploadCNHCommand>()
                .ForMember(dest => dest.ImagemCNHUrl, opt => opt.MapFrom(src => src.ImagemCNH.FileName))
                .ForMember(dest => dest.Conteudo, opt => opt.MapFrom(src => src.ImagemCNH.OpenReadStream()))
                .ForMember(dest => dest.ContentType, opt => opt.MapFrom(src => src.ImagemCNH.ContentType));
        }
    }
}
