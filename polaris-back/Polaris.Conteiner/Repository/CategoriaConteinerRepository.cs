using Polaris.Conteiner.Context;
using Polaris.Conteiner.Pagination;

namespace Polaris.Conteiner.Repository
{
    public class CategoriaConteinerRepository : Repository<Models.CategoriaConteiner>, ICategoriaConteinerRepository
    {
        public CategoriaConteinerRepository(AppDbContext context) : base(context)
        {
                
        }

        public IEnumerable<Models.CategoriaConteiner> GetCategorias(CategoriasParameters categoriasParameters)
        {
            return Get()
                .OrderBy(on => on.Nome)
                .Skip((categoriasParameters.PageNumber - 1) * categoriasParameters.PageSize)
                .Take(categoriasParameters.PageSize)
                .ToList();
        }
    }
}
