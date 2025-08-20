using MediatR;

namespace MotoDelivery.Application.Entregador.UploadCNH
{
    public class UploadCNHCommand : IRequest<UploadCNHResult>
    {
        public string Identificador { get; set; } = string.Empty;
        public string ImagemCNHUrl { get; set; } = string.Empty;
        public Stream Conteudo { get; set; } = Stream.Null;
        public string ContentType { get; set; } = string.Empty;
    }
}
