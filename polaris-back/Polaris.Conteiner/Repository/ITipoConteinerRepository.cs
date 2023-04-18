using Polaris.Conteiner.Pagination;

namespace Polaris.Conteiner.Repository
{
    public interface ITipoConteinerRepository : IRepository<Models.TipoConteiner>
    {
        IEnumerable<Models.TipoConteiner> GetTipos(TiposParameters tiposParameters);
        Task<int> GetTipoId(Guid uuid);
    }
}
