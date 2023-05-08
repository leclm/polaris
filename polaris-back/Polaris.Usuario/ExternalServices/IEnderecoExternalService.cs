using Polaris.Usuario.Models;
using Polaris.Usuario.ViewModels;

namespace Polaris.Usuario.ExternalServices
{
    public interface IEnderecoExternalService
    {
        Task<Endereco> GetEnderecos(Guid uuid);
        Task<Endereco> GetEnderecoCliente(Guid uuid);
        Task<Guid> PostEnderecos(CadastroEnderecoViewModel endereco);
        Task PutEnderecos(AtualizaEnderecoViewModel endereco);
        Task<Endereco> GetEnderecoGerente(Guid uuid);
    }
}
