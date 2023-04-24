using Polaris.Conteiner.ViewModels;

namespace Polaris.Conteiner.Services
{
    public interface IPrestacoesServicosService
    {
        Task<RetornoPrestacaoDeServicoViewModel> GetPrestacaoDeServico(Guid uuid);
    }
}
