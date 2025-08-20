using AutoMapper;
using MediatR;
using MotoDelivery.Domain.Repositories;

namespace MotoDelivery.Application.Locacao.GetLocacao
{
    public class GetLocacaoHandler : IRequestHandler<GetLocacaoCommand, GetLocacaoResult>
    {
        private readonly IMapper _mapper;
        private readonly ILocacaoRepository _locacaoRepository;

        public GetLocacaoHandler(ILocacaoRepository locacaoRepository, IMapper mapper)
        {
            _mapper = mapper;
            _locacaoRepository = locacaoRepository;
           
        }

        public async Task<GetLocacaoResult> Handle(GetLocacaoCommand request, CancellationToken cancellationToken)
        {
            var locacao = await _locacaoRepository.ObterPorIdAsync(request.LocacaoId);
            if (locacao == null)
                throw new InvalidOperationException("Locação não encontrada");

            return _mapper.Map<GetLocacaoResult>(locacao);
        }

    }
}
