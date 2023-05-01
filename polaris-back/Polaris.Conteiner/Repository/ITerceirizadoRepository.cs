using Polaris.Conteiner.Models;
using Polaris.Conteiner.Pagination;

namespace Polaris.Conteiner.Repository
{
    public interface ITerceirizadoRepository
    {
        Task<Guid> GetTerceirizadoUuid(int id);
    }
}
