using Microsoft.EntityFrameworkCore;
using Polaris.Endereco.Context;

namespace Polaris.Endereco.Repository
{
    public class EnderecoRepository : Repository<Models.Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(AppDbContext context) : base(context)
        {

        }
    }
}
