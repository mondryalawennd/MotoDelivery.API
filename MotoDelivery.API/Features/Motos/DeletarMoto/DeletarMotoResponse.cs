namespace MotoDelivery.API.Features.Motos.DeletarMoto
{
    public class DeletarMotoResponse
    {
        public string Identificador { get; set; } = string.Empty;
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; } = string.Empty;
    }
}
