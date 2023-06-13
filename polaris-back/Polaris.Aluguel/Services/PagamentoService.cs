using Braintree;
using Microsoft.Extensions.Options;
using Polaris.Aluguel.Configs;
using Polaris.Aluguel.Repository;
using Polaris.Aluguel.ViewModels;
using static Polaris.Aluguel.Exceptions.CustomExceptions;

namespace Polaris.Aluguel.Services
{
    public class PagamentoService : IPagamentoService
    {
        private readonly IUnityOfWork _context;
        private readonly BraintreeConfigs _braintreeConfig;

        public PagamentoService(IUnityOfWork context, IOptions<BraintreeConfigs> braintreeConfig)
        {
            _braintreeConfig = braintreeConfig.Value;
            _context = context;
        }

        public async Task PagarAluguelPayPal(PagarAluguelViewModel pagarAluguelDto)
        {
            var aluguel = await _context.AluguelRepository.GetAluguel(pagarAluguelDto.AluguelUuid);

            if (aluguel.EstadoAluguel == Enums.EstadoAluguel.AguardandoRetiradaConteiner)
            {
                throw new PagamentoPayPalException("O pagamento já foi solicitado.");
            }

            var gateway = _braintreeConfig.Gateway;

            var request = new TransactionRequest
            {
                Amount = Convert.ToDecimal(aluguel.ValorTotalAluguel - aluguel.Desconto),
                PaymentMethodNonce = pagarAluguelDto.Nonce,
                Options = new TransactionOptionsRequest
                {
                    SubmitForSettlement = true
                }
            };

            var result = gateway.Transaction.Sale(request);

            if (!result.IsSuccess() && result.Transaction == null)
            {
                throw new PagamentoPayPalException("Erro ao realizar o pagamento.");
            }
            else
            {
                aluguel.EstadoAluguel = Enums.EstadoAluguel.AguardandoRetiradaConteiner;
                _context.AluguelRepository.Update(aluguel);
                await _context.Commit();
            }
        }
    }
}
