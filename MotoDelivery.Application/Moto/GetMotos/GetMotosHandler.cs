using AutoMapper;
using MediatR;
using MotoDelivery.Domain.Repositories;

namespace MotoDelivery.Application.Moto.GetMotos
{
    public class GetMotosHandler : IRequestHandler<GetMotosCommand, List<GetMotosResult>>
    {
        private readonly IMapper _mapper;
        private readonly IMotoRepository _repository;

        public GetMotosHandler(IMotoRepository repo, IMapper mapper)
        {
            _repository = repo;
            _mapper = mapper;
        }

        public async Task<List<GetMotosResult>> Handle(GetMotosCommand request, CancellationToken cancellationToken)
        {
            var motos = await _repository.GetMotosAsync(request.Placa);
            return _mapper.Map<List<GetMotosResult>>(motos);
        }
    }
}