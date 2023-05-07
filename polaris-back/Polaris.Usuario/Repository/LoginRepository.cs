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
    }
}
