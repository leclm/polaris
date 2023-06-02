using NuGet.Common;
using Polaris.Usuario.ViewModels;

namespace Polaris.Usuario.Services
{
    public interface IClienteService
    {
        Task AlterarStatus(Guid uuid, bool status);
        Task<RetornoClienteViewModel> BuscarVinculoClienteAluguel(Guid uuidAluguel);
        Task<RetornoClienteViewModel> GetCliente(Guid uuid, string token);
        Task<IEnumerable<RetornoClienteViewModel>> GetClientes(string token);
        Task<IEnumerable<RetornoClienteViewModel>> GetClientesAtivos(string token);
        Task<Guid> PostCliente(CadastroClienteViewModel clienteDto, string token);
        Task PutCliente(AtualizaClienteViewModel clienteDto, string token);
    }
}
