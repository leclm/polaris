namespace Polaris.Usuario.Repository
{
    public interface ILoginRepository : IRepository<Models.Login>
    {
        Task<int> GetLoginId(Guid uuid);
    }
}
