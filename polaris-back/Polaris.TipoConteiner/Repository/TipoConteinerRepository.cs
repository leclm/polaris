using Polaris.TipoConteiner.Context;
using Polaris.TipoConteiner.Pagination;

namespace Polaris.TipoConteiner.Repository
{
    public class TipoConteinerRepository : Repository<Models.TipoConteiner>, ITipoConteinerRepository
    {
        public TipoConteinerRepository(AppDbContext context) : base(context)
        {

        }
        public IEnumerable<Models.TipoConteiner> GetTipos(TiposParameters tiposParameters)
        {
            return Get()
                .OrderBy(on => on.Nome)
                .Skip((tiposParameters.PageNumber - 1) * tiposParameters.PageSize)
                .Take(tiposParameters.PageSize)
                .ToList();
        }
    }
}
