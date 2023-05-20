namespace Polaris.Aluguel.Repository
{
    public interface IConteinerRepository : IRepository<Models.Conteiner>
    {
        (int, int, int) GetConteinerIds(Guid conteinerUuid, Guid categoriaUuid, Guid tipoUuid);
    }
}