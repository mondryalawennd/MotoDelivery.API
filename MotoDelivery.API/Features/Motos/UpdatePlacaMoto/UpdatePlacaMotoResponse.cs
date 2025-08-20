namespace MotoDelivery.API.Features.Motos.UpdatePlacaMoto
{
    public class UpdatePlacaMotoResponse
    {
        public string Identificador { get; set; } = string.Empty;
        public int Ano { get; set; }
        public string Modelo { get; set; } = string.Empty;
        public string Placa { get; set; } = string.Empty;
    }
}
