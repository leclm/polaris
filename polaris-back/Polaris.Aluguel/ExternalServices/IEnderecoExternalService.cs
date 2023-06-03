using Polaris.Aluguel.Models;
using Polaris.Aluguel.ViewModels;
using System.Reflection.Metadata;

namespace Polaris.Aluguel.ExternalServices
{
    public interface IEnderecoExternalService
    {
        Task<RetornoEnderecoViewModel> GetEnderecoAluguel(Guid uuid, string token);
        Task<Endereco> GetEnderecos(Guid uuid);
        Task<Guid> PostEnderecos(CadastroEnderecoViewModel endereco, string token);
        Task PutEnderecos(AtualizaEnderecoViewModel endereco);
    }
}
