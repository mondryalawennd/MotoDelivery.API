using AutoMapper;
using MediatR;
using MotoDelivery.Domain.Repositories;

namespace MotoDelivery.Application.Moto.UpdateMoto
{
    public class UpdatePlacaMotoHandler : IRequestHandler<UpdatePlacaMotoCommand, UpdatePlacaMotoResult>
    {
        private readonly IMapper _mapper;
        private readonly IMotoRepository _repository;

        public UpdatePlacaMotoHandler(IMotoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UpdatePlacaMotoResult> Handle(UpdatePlacaMotoCommand request, CancellationToken cancellationToken)
        {
            var moto = await _repository.ObterPorIdAsync(request.Identificador);
            if (moto == null)
                throw new InvalidOperationException("Moto não encontrada");

            if (await _repository.ExistsPlacaAsync(request.Placa, request.Identificador))
                throw new InvalidOperationException("A placa já está cadastrada em outra moto");

            moto.AlterarPlaca(request.Placa);

            await _repository.UpdateAsync(moto);

            return _mapper.Map<UpdatePlacaMotoResult>(moto);
        }
    }
}
