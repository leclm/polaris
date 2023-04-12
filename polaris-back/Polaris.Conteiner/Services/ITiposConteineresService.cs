using Polaris.Conteiner.ViewModels;

namespace Polaris.Conteiner.Services
{
    public interface ITiposConteineresService
    {
        Task<IEnumerable<RetornoTipoConteinerViewModel>> GetTipos();
        Task<RetornoTipoConteinerViewModel> GetTipo(Guid uuid);
        Task<Guid> PostTipo(CadastroTipoConteinerViewModel tipoDto);
        Task PutTipo(AtualizaTipoConteinerViewModel tipoDto);
        Task AlterarStatus(Guid uuid, bool status);
    }
}
