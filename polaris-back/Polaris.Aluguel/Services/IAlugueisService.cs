using Polaris.Aluguel.Enums;
using Polaris.Aluguel.ViewModels;

namespace Polaris.Aluguel.Services
{
    public interface IAlugueisService
    {
        Task AlterarEstadoAluguel(Guid uuid, EstadoAluguel estado, string token);
        Task AlterarStatus(Guid uuid, bool status);
        Task<IEnumerable<RetornoAluguelViewModel>> GetAlugueis(string token);
        Task<IEnumerable<RetornoAluguelViewModel>> GetAlugueisPorConteiner(int codigo, string token);
        Task<IEnumerable<RetornoAluguelViewModel>> GetAlugueisPorCpf(string cpf, string token);
        Task<RetornoAluguelViewModel> GetAluguel(Guid uuid, string token);
        Task<Guid> PostAluguel(CadastroAluguelViewModel aluguelDto, string token);
    }
}
