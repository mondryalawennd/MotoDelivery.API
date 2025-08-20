using MediatR;
using MotoDelivery.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Application.Entregador.UploadCNH
{
    public class UploadCNHHandler : IRequestHandler<UploadCNHCommand, UploadCNHResult>
    {
        private readonly IEntregadorRepository _repository;

        public UploadCNHHandler(IEntregadorRepository repository)
        {
            _repository = repository;
        }

        public async Task<UploadCNHResult> Handle(UploadCNHCommand request, CancellationToken cancellationToken)
        {
            // Simples: salva em disco local
            var pastaDestino = Path.Combine("C:\\", "CNHs");
            if (!Directory.Exists(pastaDestino))
                Directory.CreateDirectory(pastaDestino);

            var nomeArquivo = $"{request.Identificador}_{request.Identificador}{Path.GetExtension(request.ImagemCNHUrl)}";
            var caminhoCompleto = Path.Combine(pastaDestino, nomeArquivo);

            using (var fileStream = new FileStream(caminhoCompleto, FileMode.Create))
            {
                await request.Conteudo.CopyToAsync(fileStream, cancellationToken);
            }

            // Atualiza o entregador no banco com o caminho da CNH
            var entregador = await _repository.ObterPorIdAsync(request.Identificador);
            if (entregador == null)
                throw new InvalidOperationException("Entregador não encontrado.");

            entregador.AtualizarFotoCNH(caminhoCompleto);
            await _repository.UpdateAsync(entregador);

            return new UploadCNHResult
            {
                Identificador = entregador.Identificador,
                CaminhoArquivo = caminhoCompleto,
                Sucesso = true
            };
        }
    }
}