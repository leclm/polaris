using Polaris.Servico.Context;

namespace Polaris.Servico.Repository
{
    public class EnderecoRepository : Repository<Models.Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(AppDbContext context) : base(context)
        {
        }

        public int GetEnderecoId(Guid uuid)
        {
            var endereco = GetByParameter(x => x.EnderecoUuid == uuid);
            return endereco.Id;
        }
    }
}
