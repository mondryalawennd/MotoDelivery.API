using MediatR;
using MotoDelivery.Domain.Entities;
using MotoDelivery.Domain.Repositories;

namespace MotoDelivery.Application.Entregador.CreateEntregador
{
    public class CreateEntregadorHandler : IRequestHandler<CreateEntregadorCommand, CreateEntregadorResult>
    {
        private readonly IEntregadorRepository _entregadorRepository;

        public CreateEntregadorHandler(IEntregadorRepository entregadorRepository)
        {
            _entregadorRepository = entregadorRepository;
        }

        public async Task<CreateEntregadorResult> Handle(CreateEntregadorCommand request, CancellationToken cancellationToken)
        {
            

            // Verifica unicidade do CNPJ
            if (await _entregadorRepository.ExistsByCnpjAsync(request.CNPJ))
                throw new InvalidOperationException("Já existe um entregador cadastrado com este CNPJ.");

            // Verifica unicidade do Número da CNH
            if (await _entregadorRepository.ExistsByCnhAsync(request.NumeroCNH))
                throw new InvalidOperationException("Já existe um entregador cadastrado com este número de CNH.");

            var entregador = new Domain.Entities.Entregador(
                request.Identificador,
                request.Nome,
                request.CNPJ,
                request.DataNascimento,
                request.NumeroCNH,
                request.TipoCNH
            );

            await _entregadorRepository.AddAsync(entregador);

            return new CreateEntregadorResult
            {
                Identificador = entregador.Identificador,
                Nome = entregador.Nome,
                Mensagem = "Entregador cadastrado com sucesso!"
            };
        }
    }
}
