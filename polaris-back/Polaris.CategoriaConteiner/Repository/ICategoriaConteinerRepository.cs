using Polaris.CategoriaConteiner.Pagination;

namespace Polaris.CategoriaConteiner.Repository
{
    public interface ICategoriaConteinerRepository : IRepository<Models.CategoriaConteiner>
    {
        IEnumerable<Models.CategoriaConteiner> GetCategorias(CategoriasParameters categoriasParameters);
    }
}
