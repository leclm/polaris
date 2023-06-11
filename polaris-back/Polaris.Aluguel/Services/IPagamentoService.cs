using Polaris.Aluguel.ViewModels;

namespace Polaris.Aluguel.Services
{
    public interface IPagamentoService
    {
        Task PagarAluguelPayPal(PagarAluguelViewModel pagarAluguelDto);
    }
}
