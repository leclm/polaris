using Polaris.Conteiner.ViewModels;

namespace Polaris.Conteiner.Services
{
    public interface IPrestacoesServicosService
    {
        Task<RetornoPrestacaoDeServicoViewModel> GetPrestacaoDeServico(Guid uuid);
        Task<IEnumerable<RetornoPrestacaoDeServicoViewModel>> GetPrestacaoDeServicos();
        Task<Guid> PostPrestacaoDeServico(CadastroPrestacaoDeServicoViewModel prestacaoDto);
        Task PutEstadoPrestacaoDeServico(AlteraEstadoPrestacaoServico estado);
    }
}
