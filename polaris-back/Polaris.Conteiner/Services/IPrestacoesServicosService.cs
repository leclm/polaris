using Polaris.Conteiner.ViewModels;

namespace Polaris.Conteiner.Services
{
    public interface IPrestacoesServicosService
    {
        Task<RetornoPrestacaoDeServicoViewModel> GetPrestacaoDeServico(Guid uuid, string token);
        Task<Guid> PostPrestacaoDeServico(CadastroPrestacaoDeServicoViewModel prestacaoDto);
        Task PutEstadoPrestacaoDeServico(AlteraEstadoPrestacaoServico estado);
        Task<IEnumerable<RetornoPrestacaoDeServicoViewModel>> GetPrestacoesServicosPorConteiner(Guid uuidConteiner, string token);
        Task<IEnumerable<RetornoPrestacaoDeServicoViewModel>> GetPrestacaoDeServicos(string token);
    }
}
