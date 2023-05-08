using Polaris.Usuario.Models;

namespace Polaris.Usuario.Repository
{
    public interface ILoginRepository : IRepository<Models.Login>
    {
        Task<Login> GetLogin(Guid uuid);
        Task<int> GetLoginId(Guid uuid);
    }
}
