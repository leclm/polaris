using Polaris.Servico.Models;
using Polaris.Servico.ViewModels;

namespace Polaris.Servico.ExternalServices
{
    public interface IEnderecoExternalService
    {
        Task<Endereco> GetEnderecos(Guid uuid);
        Task<Guid> PostEnderecos(CadastroEnderecoViewModel endereco);
        Task<Guid> PutEnderecos(AtualizaEnderecoViewModel endereco);
    }
}
