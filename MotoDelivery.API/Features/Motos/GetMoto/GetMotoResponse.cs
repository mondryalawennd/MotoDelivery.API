namespace MotoDelivery.API.Features.Motos.GetMoto
{
    public class GetMotoResponse
    {
        public string Identificador { get; set; } = string.Empty;
        public int Ano { get; set; }
        public string Modelo { get; set; } = string.Empty;
        public string Placa { get; set; } = string.Empty;
    }
}
