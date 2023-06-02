using Polaris.Servico.Models;
using Polaris.Servico.ViewModels;

namespace Polaris.Servico.ExternalServices
{
    public interface IEnderecoExternalService
    {
        Task<Endereco> GetEnderecos(Guid uuid, string token);
        Task<Endereco> GetEnderecoTerceirizado(Guid uuid, string token);
        Task<Guid> PostEnderecos(CadastroEnderecoViewModel endereco, string token);
        Task PutEnderecos(AtualizaEnderecoViewModel endereco, string token);
    }
}
