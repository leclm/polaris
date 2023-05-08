using Microsoft.EntityFrameworkCore;
using Polaris.Usuario.Context;
using Polaris.Usuario.Models;

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

        public async Task<Models.Login> GetLogin(Guid uuid)
        {
            return await _context.Set<Login>().AsNoTracking().Where(x => x.LoginUuid == uuid)
                .FirstOrDefaultAsync();
        }
    }
}
