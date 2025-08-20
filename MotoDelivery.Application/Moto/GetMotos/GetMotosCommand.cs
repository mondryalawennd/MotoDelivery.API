using MediatR;

namespace MotoDelivery.Application.Moto.GetMotos
{
    public class GetMotosCommand : IRequest<List<GetMotosResult>>
    {
        public string? Placa { get; set; }
    }
}

