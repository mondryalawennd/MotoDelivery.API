using MediatR;
using MotoDelivery.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Application.Moto.DeleteMotos
{
    public class DeleteMotoHandler : IRequestHandler<DeleteMotoCommand, DeleteMotoResult>
    {
        private readonly IMotoRepository _motoRepository;
        private readonly ILocacaoRepository _locacaoRepository;

        public DeleteMotoHandler(IMotoRepository motoRepository, ILocacaoRepository locacaoRepository)
        {
            _motoRepository = motoRepository;
            _locacaoRepository = locacaoRepository;
        }

        public async Task<DeleteMotoResult> Handle(DeleteMotoCommand request, CancellationToken cancellationToken)
        {
            var moto = await _motoRepository.ObterPorIdAsync(request.Identificador);
            if (moto == null)
                throw new InvalidOperationException("Moto não encontrada");

            // verifica se existem locações associadas
            bool possuiLocacoes = await _locacaoRepository.ExistsByMotoIdAsync(request.Identificador);
            if (possuiLocacoes)
                throw new InvalidOperationException("Não é possível remover a moto pois existem registros de locações vinculados");

            await _motoRepository.DeleteAsync(moto);

            return new DeleteMotoResult
            {
                Identificador = request.Identificador,
                Sucesso = true,
                Mensagem = "Moto removida com sucesso."
            };
        }
    }
}