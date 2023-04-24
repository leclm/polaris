using Polaris.Conteiner.Models;

namespace Polaris.Conteiner.Repository
{
    public interface IPrestacaoServicoRepository
    {
        Task<PrestacaoDeServico> GetPrestacaoDeServico(Guid uuid);
    }
}
