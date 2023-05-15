namespace Polaris.Aluguel.Repository
{
    public interface IConteinerRepository : IRepository<Models.Conteiner>
    {
        int GetConteinerID(Guid uuid);
    }
}