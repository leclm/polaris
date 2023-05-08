using Polaris.Usuario.Context;

namespace Polaris.Usuario.Repository
{
    public class LoginRepository : Repository<Models.Login>, ILoginRepository
    {
        private readonly AppDbContext _context;
        public LoginRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<int> GetLoginId(Guid uuid)
        {
            var login = await GetByParameter(x => x.LoginUuid == uuid);
            return login.LoginId;
        }
    }
}
