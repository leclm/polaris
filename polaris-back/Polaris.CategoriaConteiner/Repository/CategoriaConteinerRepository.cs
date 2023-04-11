using Polaris.CategoriaConteiner.Context;
using Polaris.CategoriaConteiner.Pagination;

namespace Polaris.CategoriaConteiner.Repository
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
