using MotoDelivery.Domain.Enum;
using System.Text.Json.Serialization;

namespace MotoDelivery.API.Features.Locacao.CreateLocacao
{
    public class CreateLocacaoRequest
    {
        public string EntregadorId { get; set; } = string.Empty;
        public string MotoId { get; set; } = string.Empty;
        public PlanoLocacao Plano { get; set; }
        [JsonIgnore]
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public string DataInicio { get; set; } = string.Empty;
        public string DataTermino { get; set; } = string.Empty;
        public string DataPrevisaoTermino { get; set; } = string.Empty;


    }
}
