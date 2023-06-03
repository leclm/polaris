using Polaris.Usuario.Models;
using Polaris.Usuario.ViewModels;

namespace Polaris.Usuario.ExternalServices
{
    public interface IEnderecoExternalService
    {
        Task<Endereco> GetEnderecos(Guid uuid, string token);
        Task<Endereco> GetEnderecoCliente(Guid uuid, string token);
        Task<Guid> PostEnderecos(CadastroEnderecoViewModel endereco, string token);
        Task PutEnderecos(AtualizaEnderecoViewModel endereco, string token);
        Task<Endereco> GetEnderecoGerente(Guid uuid, string token);
    }
}
