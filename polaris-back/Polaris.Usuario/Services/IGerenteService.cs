using Polaris.Usuario.ViewModels;

namespace Polaris.Usuario.Services
{
    public interface IGerenteService
    {
        Task AlterarStatus(Guid uuid, bool status);
        Task<RetornoGerenteViewModel> GetGerente(Guid uuid);
        Task<IEnumerable<RetornoGerenteViewModel>> GetGerentes();
        Task<IEnumerable<RetornoGerenteViewModel>> GetGerentesAtivos();
        Task<Guid> PostGerente(CadastroGerenteViewModel gerenteDto);
        Task PutGerente(AtualizaGerenteViewModel gerenteDto);
    }
}
