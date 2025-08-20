using MediatR;

namespace MotoDelivery.Application.Moto.GetMoto
{
    public class GetMotoCommand : IRequest<GetMotoResult>
    {
        public string Identificador { get; set; } = string.Empty;

        public GetMotoCommand(string identificador)
        {
            Identificador = identificador;
        }

        // Construtor vazio necessário para AutoMapper ou deserialização
        public GetMotoCommand() { }
    }
}

