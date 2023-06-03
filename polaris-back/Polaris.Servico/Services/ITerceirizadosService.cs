using Polaris.Servico.ViewModels;

namespace Polaris.Servico.Services
{
    public interface ITerceirizadosService
    {
        Task<IEnumerable<RetornoTerceirizadoViewModel>> GetTerceirizadosPorServico(string servico, string token);
        Task<IEnumerable<RetornoTerceirizadoViewModel>> GetTerceirizados(string token);
        Task<IEnumerable<RetornoTerceirizadoViewModel>> GetTerceirizadosAtivos(string token);
        Task<RetornoTerceirizadoViewModel> GetTerceirizado(Guid uuid, string token);
        Task<Guid> PostTerceirizado(CadastroTerceirizadoViewModel terceirizadoDto, string token);
        Task PutTerceirizado(AtualizaTerceirizadoViewModel terceirizadoDto, string token);
        Task AlterarStatus(Guid uuid, bool status);
        Task<RetornoTerceirizadoViewModel> GetTerceirizadoByPrestacaoDeServico(Guid uuidPrestacaoDeServico, string token);
   
    }
}
