using Polaris.Usuario.ViewModels;

namespace Polaris.Usuario.Services
{
    public interface IGerenteService
    {
        Task AlterarStatus(Guid uuid, bool status);
        Task<RetornoGerenteViewModel> GetGerente(Guid uuid, string token);
        Task<IEnumerable<RetornoGerenteViewModel>> GetGerentes(string token);
        Task<IEnumerable<RetornoGerenteViewModel>> GetGerentesAtivos(string token);
        Task<Guid> PostGerente(CadastroGerenteViewModel gerenteDto, string token);
        Task PutGerente(AtualizaGerenteViewModel gerenteDto, string token);
    }
}
