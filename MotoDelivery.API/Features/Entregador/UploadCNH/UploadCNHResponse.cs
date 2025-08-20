namespace MotoDelivery.API.Features.Entregador.UploadCNH
{
    public class UploadCNHResponse
    {
        public string EntregadorId { get; set; } = string.Empty;
        public string CaminhoArquivo { get; set; } = string.Empty;
        public bool Sucesso { get; set; }
    }
}
