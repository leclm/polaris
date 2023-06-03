using Polaris.Conteiner.Models;
using Polaris.Conteiner.ViewModels;

namespace Polaris.Conteiner.ExternalServices
{
    public interface IServicoExternalService
    {
        Task<BuscaServicoViewModel> GetServico(Guid uuid, string token);
        Task<RetornoTerceirizadoViewModel> GetTerceirizado(Guid uuid, string token);
    }
}
