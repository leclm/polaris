using Polaris.Conteiner.Enums;
using Polaris.Conteiner.ViewModels;

namespace Polaris.Conteiner.Services
{
    public interface IConteineresService
    {
        Task<IEnumerable<RetornoConteinerViewModel>> GetConteineresPorCategoria(string categoria);
        Task<IEnumerable<RetornoConteinerViewModel>> GetConteineresPorTipo(string tipo);
        Task<IEnumerable<RetornoConteinerViewModel>> GetConteineres();
        Task<IEnumerable<RetornoConteinerViewModel>> GetConteineresAtivos();
        Task<RetornoConteinerViewModel> GetConteiner(Guid uuid);
        Task<Guid> PostConteiner(CadastroConteinerViewModel conteinerDto);
        Task PutConteiner(AtualizaConteinerViewModel conteinerDto);
        Task AlterarStatus(Guid uuid, bool status);
        Task AlterarDisponibilidade(Guid uuid, EstadoConteiner estado);
        Task<IEnumerable<RetornoConteinerViewModel>> GetConteineresAtivosDisponiveis();
        Task<IEnumerable<RetornoConteinerViewModel>> GetConteineresAtivosDisponiveisPorCategoriaETipo(Guid categoriaUUid, Guid tipoUuid);
        Task<IEnumerable<RetornoConteinerViewModel>> BuscarVinculoConteinerAluguel(Guid uuidAluguel);
    }
}
