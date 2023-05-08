namespace Polaris.Usuario.Repository
{
    public interface IGerenteRepository : IRepository<Models.Gerente>
    {
        IEnumerable<Models.Gerente> GenteGerentesCompleto();
        IEnumerable<Models.Gerente> GetGerentesAtivosCompleto();
        Task<Models.Gerente> GetGerente(Guid uuid);
    }
}
