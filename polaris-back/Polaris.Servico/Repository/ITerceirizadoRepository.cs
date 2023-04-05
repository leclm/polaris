using Polaris.Servico.Pagination;

namespace Polaris.Servico.Repository
{
    public interface ITerceirizadoRepository : IRepository<Models.Terceirizado>
    {
        IEnumerable<Models.Terceirizado> GetTerceirizados(TerceirizadosParameters terceirizadosParameters);
        IEnumerable<Models.Terceirizado> GetTerceirizadosPorServico(string servico);   
    }
}
