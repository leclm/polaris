namespace Polaris.Aluguel.Repository
{
    public interface IEnderecoRepository
    {
        Task<int> GetEnderecoId(Guid uuid);
    }
}
