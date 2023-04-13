using Polaris.Conteiner.Pagination;

namespace Polaris.Conteiner.Repository
{
    public interface IConteinerRepository : IRepository<Models.Conteiner>
    {
        IEnumerable<Models.Conteiner> GetConteineresCompleto();
        IEnumerable<Models.Conteiner> GetConteineresAtivosCompleto();
        IEnumerable<Models.Conteiner> GetConteineres(ConteinerParameters conteinerParameters);
        IEnumerable<Models.Conteiner> GetConteineresPorCategoria(string categoria);
        IEnumerable<Models.Conteiner> GetConteineresPorTipo(string tipo);
        Task<Models.Conteiner> GetConteiner(Guid uuid);
    }
}
