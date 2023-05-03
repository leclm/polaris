using Polaris.Conteiner.Models;

namespace Polaris.Conteiner.Repository
{
    public interface IPrestacaoServicoRepository : IRepository<Models.PrestacaoDeServico>
    {
        IEnumerable<PrestacaoDeServico> GetPrestacaoCompleta();
        Task<PrestacaoDeServico> GetPrestacaoDeServico(Guid uuid);
        IEnumerable<Models.PrestacaoDeServico> GetPrestacoesServicosPorConteiner(Guid uuidConteiner);
    }
}
