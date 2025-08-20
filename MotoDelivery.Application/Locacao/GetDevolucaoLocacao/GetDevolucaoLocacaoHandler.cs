using AutoMapper;
using MediatR;
using MotoDelivery.Application.Moto.CreateMoto;
using MotoDelivery.Domain.Entities;
using MotoDelivery.Domain.Repositories;
using MotoDelivery.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Application.Locacao.GetDevolucaoLocacao
{
    public class GetDevolucaoHandler : IRequestHandler<GetDevolucaoCommand, GetDevolucaoLocacaoResult>
    {
        private readonly IMapper _mapper;
        private readonly ILocacaoRepository _locacaoRepository;
        private readonly ILocacaoService _locacaoService;

        public GetDevolucaoHandler(IMapper mapper, ILocacaoRepository locacaoRepository, ILocacaoService locacaoService)
        {
            _mapper = mapper;
            _locacaoRepository = locacaoRepository;
            _locacaoService = locacaoService;
        }

        public async Task<GetDevolucaoLocacaoResult> Handle(GetDevolucaoCommand request, CancellationToken cancellationToken)
        {
            var locacao = await _locacaoRepository.ObterPorIdAsync(request.LocacaoId);
            if (locacao == null)
                throw new InvalidOperationException("Locação não encontrada");

            // calcular valor e regras
            var locacaoEntisty = _locacaoService.CalcularValorDevolucao(locacao, request.DataDevolucao);

            locacao.ValorDiaria = locacaoEntisty;
            locacao.DataPrevisaoTermino = request.DataDevolucao;

           return _mapper.Map<GetDevolucaoLocacaoResult>(locacao);
        }
    }
}