using Polaris.Aluguel.Enums;
using Polaris.Aluguel.ViewModels;

namespace Polaris.Aluguel.Services
{
    public interface IAlugueisService
    {
        Task AlterarEstadoAluguel(Guid uuid, EstadoAluguel estado);
        Task AlterarStatus(Guid uuid, bool status);
        Task<IEnumerable<RetornoAluguelViewModel>> GetAlugueis();
        Task<IEnumerable<RetornoAluguelViewModel>> GetAlugueisPorCpf(string cpf);
        Task<RetornoAluguelViewModel> GetAluguel(Guid uuid);
        Task<Guid> PostAluguel(CadastroAluguelViewModel aluguelDto);
    }
}
