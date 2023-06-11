using Braintree;

namespace Polaris.Aluguel.Configs
{
    public class BraintreeConfigs
    {
        public string Environment { get; set; }
        public string MerchantId { get; set; }
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
        public BraintreeGateway Gateway { 
            get 
            { 
                return new BraintreeGateway(Environment, MerchantId, PublicKey, PrivateKey); 
            } 
        }
    }
}
