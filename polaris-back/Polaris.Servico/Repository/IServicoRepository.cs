using Polaris.Servico.Models;
using Polaris.Servico.Pagination;

namespace Polaris.Servico.Repository
{
    public interface IServicoRepository : IRepository<Models.Servico>
    {
        IEnumerable<Models.Servico> GetServicos(ServicosParameters servicosParameters);
        IEnumerable<Models.Servico> GetServicosPorTerceirizado(string cnpj);
        Task<Models.Servico?> GetServicoByPrestacaoDeServico(Guid uuidPrestacaoDeServico);
    }
}
