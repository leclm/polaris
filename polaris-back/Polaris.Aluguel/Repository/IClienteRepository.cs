namespace Polaris.Aluguel.Repository
{
    public interface IClienteRepository : IRepository<Models.Cliente>
    {
        int GetClienteId(Guid uuid);
    }
}
