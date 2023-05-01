using Polaris.Conteiner.Pagination;

namespace Polaris.Conteiner.Repository
{
    public interface IServicoRepository : IRepository<Models.Servico>
    {
        int GetServicoId(Guid uuid);
    }
}
