using Polaris.Servico.Models;
using Polaris.Servico.Pagination;

namespace Polaris.Servico.Repository
{
    public interface ITerceirizadoRepository : IRepository<Models.Terceirizado>
    {
        Task<Terceirizado> GetTerceirizado(Guid uuid);
        IEnumerable<Models.Terceirizado> GetTerceirizados(TerceirizadosParameters terceirizadosParameters);
        IEnumerable<Terceirizado> GetTerceirizadosAtivosCompleto();
        IEnumerable<Terceirizado> GetTerceirizadosCompleto();
        IEnumerable<Models.Terceirizado> GetTerceirizadosPorServico(string servico);   
    }
}
