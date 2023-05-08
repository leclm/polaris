using Polaris.Usuario.ViewModels;

namespace Polaris.Usuario.Services
{
    public interface IClienteService
    {
        Task AlterarStatus(Guid uuid, bool status);
        Task<RetornoClienteViewModel> GetCliente(Guid uuid);
        Task<IEnumerable<RetornoClienteViewModel>> GetClientes();
        Task<IEnumerable<RetornoClienteViewModel>> GetClientesAtivos();
        Task<Guid> PostCliente(CadastroClienteViewModel clienteDto);
        Task PutCliente(AtualizaClienteViewModel clienteDto);
    }
}
