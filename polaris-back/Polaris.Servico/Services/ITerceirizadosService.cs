using Polaris.Servico.Models;
using Polaris.Servico.ViewModels;
using System.Threading.Tasks;

namespace Polaris.Servico.Services
{
    public interface ITerceirizadosService
    {
        Task<IEnumerable<RetornoTerceirizadoViewModel>> GetTerceirizadosPorServico(string servico);
        Task<IEnumerable<RetornoTerceirizadoViewModel>> GetTerceirizados();
        Task<IEnumerable<RetornoTerceirizadoViewModel>> GetTerceirizadosAtivos();
        Task<RetornoTerceirizadoViewModel> GetTerceirizado(Guid uuid);
        Task<Guid> PostTerceirizado(CadastroTerceirizadoViewModel terceirizadoDto);
        Task PutTerceirizado(AtualizaTerceirizadoViewModel terceirizadoDto);
        Task AlterarStatus(Guid uuid, bool status);
        Task<RetornoTerceirizadoViewModel> GetTerceirizadoByPrestacaoDeServico(Guid uuidPrestacaoDeServico);
    }
}
