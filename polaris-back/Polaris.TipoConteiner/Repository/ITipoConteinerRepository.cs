using Polaris.TipoConteiner.Pagination;

namespace Polaris.TipoConteiner.Repository
{
    public interface ITipoConteinerRepository : IRepository<Models.TipoConteiner>
    {
        IEnumerable<Models.TipoConteiner> GetTipos(TiposParameters tiposParameters);
    }
}
