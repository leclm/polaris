using Polaris.Aluguel.Pagination;

namespace Polaris.Aluguel.Repository
{
    public interface IAluguelRepository : IRepository<Models.Aluguel>
    {
        IEnumerable<Models.Aluguel> GetAlugueis(AluguelParameters aluguelParameters);
        IEnumerable<Models.Aluguel> GetAlugueisCompletos();
        Task<Models.Aluguel> GetAluguel(Guid uuid);
    }
}
