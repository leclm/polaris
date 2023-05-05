namespace Polaris.Usuario.Repository
{
    public interface IEnderecoRepository
    {
        Task<int> GetEnderecoId(Guid uuid);
    }
}
