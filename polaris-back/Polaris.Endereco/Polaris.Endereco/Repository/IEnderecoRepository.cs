namespace Polaris.Endereco.Repository
{
    public interface IEnderecoRepository : IRepository<Models.Endereco>
    {
        Task<Models.Endereco> GetEnderecoByTerceirizado(Guid uuidTerceirizado);
    }
}
