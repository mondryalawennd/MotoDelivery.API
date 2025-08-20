using AutoMapper;
using MediatR;
using MotoDelivery.Domain.Entities;
using MotoDelivery.Domain.Repositories;
using MotoDelivery.Domain.Services;
using Locacao_ = MotoDelivery.Domain.Entities.Locacao;

namespace MotoDelivery.Application.Locacao.CreateLocacao
{
    public class CreateLocacaoHandler : IRequestHandler<CreateLocacaoCommand, CreateLocacaoResult>
    {
        private readonly IMapper _mapper;
        private readonly IEntregadorRepository _entregadorRepository;
        private readonly IMotoRepository _motoRepository;
        private readonly ILocacaoRepository _locacaoRepository;

        public CreateLocacaoHandler(IMapper mapper, IEntregadorRepository entregadorRepository, IMotoRepository motoRepository, ILocacaoRepository locacaoRepository)
        {
            _mapper = mapper;
            _motoRepository = motoRepository;
            _locacaoRepository = locacaoRepository;
            _entregadorRepository = entregadorRepository;           
            
        }

        public async Task<CreateLocacaoResult> Handle(CreateLocacaoCommand request, CancellationToken cancellationToken)
        {
            var entregador = await _entregadorRepository.ObterPorIdAsync(request.EntregadorId);
            if (entregador == null) throw new InvalidOperationException("Entregador não encontrado");
            if (entregador.TipoCNH != "A") throw new InvalidOperationException("Somente entregadores categoria 'A' efetuar uma locação.");

            var moto = await _motoRepository.ObterPorIdAsync(request.MotoId);
            if (moto == null) throw new InvalidOperationException("Moto não encontrada");
            if (await _locacaoRepository.ExistsByMotoIdAsync(request.MotoId)) throw new InvalidOperationException("Moto já alugada");

            var locacao = new Locacao_(request.EntregadorId, request.MotoId, request.Plano, request.DataInicio, request.DataTermino, request.DataPrevisaoTermino);

            await _locacaoRepository.AddAsync(locacao);

            return _mapper.Map<CreateLocacaoResult>(locacao);
        }
    }
}
