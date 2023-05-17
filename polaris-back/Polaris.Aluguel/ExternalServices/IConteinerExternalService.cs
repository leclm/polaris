using Polaris.Aluguel.Models;

namespace Polaris.Aluguel.ExternalServices
{
    public interface IConteinerExternalService
    {
        Task<IEnumerable<Conteiner>> GetConteineres(Guid uuid);
        Task<IEnumerable<Conteiner>> GetConteineresAluguel(Guid uuid);
    }
}
