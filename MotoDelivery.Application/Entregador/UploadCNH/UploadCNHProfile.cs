using AutoMapper;
using Entregador_ = MotoDelivery.Domain.Entities.Entregador;

namespace MotoDelivery.Application.Entregador.UploadCNH
{
    public class UploadCNHProfile: Profile
    {
        public UploadCNHProfile()
        {
            CreateMap<Entregador_, UploadCNHResult>();
        }
    }
}
