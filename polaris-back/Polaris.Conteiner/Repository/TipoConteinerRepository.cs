using Polaris.Conteiner.Context;
using Polaris.Conteiner.Pagination;

namespace Polaris.Conteiner.Repository
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
        public async Task<int> GetTipoId(Guid uuid)
        {
            var tipo = await GetByParameter(x => x.TipoConteinerUuid == uuid);
            return tipo.TipoConteineroId;
        }
    }
}
