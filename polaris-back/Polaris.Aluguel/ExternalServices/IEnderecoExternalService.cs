using Polaris.Aluguel.Models;
using Polaris.Aluguel.ViewModels;

namespace Polaris.Aluguel.ExternalServices
{
    public interface IEnderecoExternalService
    {
        Task<RetornoEnderecoViewModel> GetEnderecoAluguel(Guid uuid);
        Task<Endereco> GetEnderecos(Guid uuid);
        Task<Guid> PostEnderecos(CadastroEnderecoViewModel endereco);
        Task PutEnderecos(AtualizaEnderecoViewModel endereco);
    }
}
