using AutoMapper;
using MediatR;
using MotoDelivery.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Application.Moto.GetMoto
{
    public class GetMotoHandler : IRequestHandler<GetMotoCommand, GetMotoResult>
    {
        private readonly IMapper _mapper;
        private readonly IMotoRepository _repository;

        public GetMotoHandler(IMotoRepository repo, IMapper mapper)
        {
            _repository = repo;
            _mapper = mapper;
        }

        public async Task<GetMotoResult> Handle(GetMotoCommand request, CancellationToken cancellationToken)
        {
            var motos = await _repository.ObterPorIdAsync(request.Identificador);
            return _mapper.Map<GetMotoResult>(motos);
        }
    }
}