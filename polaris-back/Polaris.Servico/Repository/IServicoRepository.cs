using Polaris.Servico.Pagination;

namespace Polaris.Servico.Repository
{
    public interface IServicoRepository : IRepository<Models.Servico>
    {
        IEnumerable<Models.Servico> GetServicos(ServicosParameters servicosParameters);
    }
}
