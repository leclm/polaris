using Polaris.Aluguel.Models;
using Polaris.Aluguel.ViewModels;

namespace Polaris.Aluguel.ExternalServices
{
    public interface IConteinerExternalService
    {
        void AlterarDisponibilidadeConteiner(Guid uuid, int estado);
        Task<RetornoConteinerViewModel> GetConteineres(Guid uuid);
        Task<IEnumerable<RetornoConteinerViewModel>> GetConteineresAluguel(Guid uuid);
    }
}
