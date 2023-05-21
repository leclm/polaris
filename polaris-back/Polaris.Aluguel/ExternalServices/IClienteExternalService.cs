using Polaris.Aluguel.Models;
using Polaris.Aluguel.ViewModels;

namespace Polaris.Aluguel.ExternalServices
{
    public interface IClienteExternalService
    {
        Task<RetornoClienteViewModel> GetClienteAluguel(Guid uuid);
        Task<Cliente> GetClientes(Guid uuid);
    }
}
