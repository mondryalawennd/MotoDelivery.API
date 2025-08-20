namespace MotoDelivery.API.Features.Entregador.UploadCNH
{
    public class UploadCNHRequest
    {
        public string Identificador { get; set; } = string.Empty;
        public IFormFile ImagemCNH { get; set; } = null!;
    }
}
