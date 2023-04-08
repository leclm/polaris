namespace Polaris.Servico.Repository
{
    public interface IEnderecoRepository
    {
        Task<int> GetEnderecoId(Guid uuid);
    }
}
