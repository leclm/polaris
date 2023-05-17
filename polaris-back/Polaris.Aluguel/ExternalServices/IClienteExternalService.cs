using Polaris.Aluguel.Models;

namespace Polaris.Aluguel.ExternalServices
{
    public interface IClienteExternalService
    {
        Task<Cliente> GetClienteAluguel(Guid uuid);
        Task<Cliente> GetClientes(Guid uuid);
    }
}
