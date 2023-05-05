using Polaris.Usuario.Context;

namespace Polaris.Usuario.Repository
{
    public class EnderecoRepository : Repository<Models.Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<int> GetEnderecoId(Guid uuid)
        {
            var endereco = await GetByParameter(x => x.EnderecoUuid == uuid);
            return endereco.EnderecoId;
        }
    }
}
