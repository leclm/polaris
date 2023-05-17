namespace Polaris.Endereco.Repository
{
    public interface IEnderecoRepository : IRepository<Models.Endereco>
    {
        Task<Models.Endereco> GetEnderecoByTerceirizado(Guid uuidTerceirizado);
        Task<Models.Endereco> GetEnderecoByCliente(Guid uuidCliente);
        Task<Models.Endereco> GetEnderecoByGerente(Guid uuidGerente);
        Task<Models.Endereco?> GetEnderecoByAluguel(Guid uuidAluguel);
    }
}
