using Polaris.Endereco.DTOs;

namespace Polaris.Endereco.Services
{
    public interface IEnderecosService
    {
        Task<IEnumerable<RetornoEnderecoViewModel>> GetEnderecos();
        Task<RetornoEnderecoViewModel> GetEndereco(Guid uuid);
        Task<Guid> PostEndereco(CadastroEnderecoViewModel enderecoDto);
        Task PutEndereco(AtualizaEnderecoViewModel enderecoDto);
        Task AlterarStatus(Guid uuid, bool status);
        Task<RetornoEnderecoViewModel> BuscarVinculoEnderecoTerceirizado(Guid uuidTerceirizado);
        Task<RetornoEnderecoViewModel> BuscarVinculoEnderecoCliente(Guid uuidCliente);
        Task<RetornoEnderecoViewModel> BuscarVinculoEnderecoGerente(Guid uuidGerente);
        Task<RetornoEnderecoViewModel> BuscarVinculoEnderecoAluguel(Guid uuidAluguel);
    }
}
