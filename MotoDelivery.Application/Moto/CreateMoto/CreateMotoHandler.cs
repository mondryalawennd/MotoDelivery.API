using AutoMapper;
using MassTransit;
using MediatR;
using MotoDelivery.Domain.Events;
using MotoDelivery.Domain.Repositories;
using MotoDelivery.Domain.Services;
using Motos = MotoDelivery.Domain.Entities.Moto;

namespace MotoDelivery.Application.Moto.CreateMoto
{
    public class CreateMotoHandler : IRequestHandler<CreateMotoCommand, CreateMotoResult>
    {

        private readonly IMapper _mapper;
        private readonly IMotoRepository _repository;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IEventoService _eventoService;

        public CreateMotoHandler(IMotoRepository repo, IPublishEndpoint publishEndpoint, IMapper mapper, IEventoService eventoService)
        {
            _mapper = mapper;
            _repository = repo;     
            _eventoService = eventoService;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<CreateMotoResult> Handle(CreateMotoCommand command, CancellationToken cancellationToken)
        {
            // Gera identificador se não fornecido
            var id = string.IsNullOrEmpty(command.Identificador)
                     ? Guid.NewGuid().ToString()
                     : command.Identificador;

            // Valida placa única
            if (await _repository.ExistsPlacaAsync(command.Placa))
                throw new InvalidOperationException("Placa já cadastrada");

            // Valida identificador único
            if (await _repository.ExistsByIdAsync(id))
                throw new InvalidOperationException("Identificador já cadastrado");

            var moto = new Motos(id, command.Ano, command.Modelo, command.Placa);

            await _repository.AddAsync(moto);

            var evento = new CreateMotoEvent(moto.Identificador, moto.Ano, moto.Modelo, moto.Placa);
           await _publishEndpoint.Publish(evento, cancellationToken);
          

            return _mapper.Map<CreateMotoResult>(moto);
        }
    }
}