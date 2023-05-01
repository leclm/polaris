using Polaris.Conteiner.Pagination;

namespace Polaris.Conteiner.Repository
{
    public interface IServicoRepository : IRepository<Models.Servico>
    {
        IEnumerable<Models.Servico> GetServicos(ServicosParameters servicosParameters);
        IEnumerable<Models.Servico> GetServicosPorTerceirizado(string cnpj);
    }
}
