using Microsoft.Extensions.Options;
using Polaris.Servico.Configs;

namespace Polaris.Servico.ExternalServices
{
    public class EnderecoExternalService : IEnderecoExternalService
    {
        private readonly ExternalConfigs _config;
        public EnderecoExternalService(IOptions<ExternalConfigs> config)
        {
            _config = config.Value;
        }

        public void Teste()
        {
            var temp = _config;
        }
    }
}
