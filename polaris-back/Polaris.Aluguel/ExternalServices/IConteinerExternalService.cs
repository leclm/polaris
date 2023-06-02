using Polaris.Aluguel.Models;
using Polaris.Aluguel.ViewModels;

namespace Polaris.Aluguel.ExternalServices
{
    public interface IConteinerExternalService
    {
        void AlterarDisponibilidadeConteiner(Guid uuid, int estado, string token);
        Task<RetornoConteinerViewModel> GetConteineres(Guid uuid, string token);
        Task<IEnumerable<RetornoConteinerViewModel>> GetConteineresAluguel(Guid uuid, string token);
    }
}
