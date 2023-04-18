using Polaris.Conteiner.Pagination;

namespace Polaris.Conteiner.Repository
{
    public interface ICategoriaConteinerRepository : IRepository<Models.CategoriaConteiner>
    {
        IEnumerable<Models.CategoriaConteiner> GetCategorias(CategoriasParameters categoriasParameters);
        Task<int> GetCategoriaId(Guid uuid);
    }
}
