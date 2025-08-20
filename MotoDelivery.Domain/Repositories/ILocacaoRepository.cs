using MotoDelivery.Domain.Entities;

namespace MotoDelivery.Domain.Repositories
{
    public interface ILocacaoRepository
    {
        Task<Locacao?> ObterPorIdAsync(string id);
        Task<bool> ExistsByMotoIdAsync(string motoId);
        Task AddAsync(Locacao locacao);
    }
}
