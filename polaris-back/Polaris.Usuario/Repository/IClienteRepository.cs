using Polaris.Usuario.Models;

namespace Polaris.Usuario.Repository
{
    public interface IClienteRepository : IRepository<Models.Cliente>
    {
        IEnumerable<Models.Cliente> GetClientesCompleto();
        IEnumerable<Models.Cliente> GetClientesAtivosCompleto();
        Task<Models.Cliente> GetCliente(Guid uuid);
        Task<Cliente?> GetClienteByAluguel(Guid uuidAluguel);
    }
}
