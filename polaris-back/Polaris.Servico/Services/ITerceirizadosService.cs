using Polaris.Servico.ViewModels;
using System.Threading.Tasks;

namespace Polaris.Servico.Services
{
    public interface ITerceirizadosService
    {
        Task<IEnumerable<RetornoTerceirizadoViewModel>> GetTerceirizados();
        Task<RetornoTerceirizadoViewModel> GetTerceirizado(Guid uuid);
        Task<Guid> PostTerceirizado(CadastroTerceirizadoViewModel terceirizadoDto);
        Task PutTerceirizado(AtualizaTerceirizadoViewModel terceirizadoDto);
        Task AlterarStatus(Guid uuid, bool status);
    }
}
