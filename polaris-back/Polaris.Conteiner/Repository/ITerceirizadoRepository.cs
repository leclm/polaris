using Polaris.Conteiner.Models;
using Polaris.Conteiner.Pagination;

namespace Polaris.Conteiner.Repository
{
    public interface ITerceirizadoRepository : IRepository<Terceirizado>
    {
        int GetTerceirizadoId(Guid uuid);
    }
}
