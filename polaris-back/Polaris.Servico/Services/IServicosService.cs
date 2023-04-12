using Polaris.Servico.ViewModels;

namespace Polaris.Servico.Services
{
    public interface IServicosService
    {
        IEnumerable<RetornoServicoViewModel> GetServicosPorTerceirizado(string cnpj);
        Task<IEnumerable<RetornoServicoViewModel>> GetServicos();
        Task<IEnumerable<RetornoServicoViewModel>> GetServicosAtivos();
        Task<RetornoServicoViewModel> GetServico(Guid uuid);
        Task<Guid> PostServico(CadastroServicoViewModel servicoDto);
        Task PutServico(AtualizaServicoViewModel servicoDto);
        Task AlterarStatus(Guid uuid, bool status);
    }
}
