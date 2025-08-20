using MotoDelivery.Domain.Enum;

namespace MotoDelivery.API.Features.Entregador.CreateEntregador
{
    public class CreateEntregadorRequest
    {
        public string Identificador { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string CNPJ { get; set; } = string.Empty;
        public string DataNascimento { get; set; } = string.Empty;
        public string NumeroCNH { get; set; } = string.Empty;
        public string TipoCNH { get; set; } = string.Empty;
    }
}
