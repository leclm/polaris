using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Options;
using Polaris.Aluguel.Configs;
using Polaris.Aluguel.Models;
using Polaris.Aluguel.ViewModels;

namespace Polaris.Aluguel.ExternalServices
{
    public class ClienteExternalService : IClienteExternalService
    {
        private readonly ExternalConfigs _config;
        public ClienteExternalService(IOptions<ExternalConfigs> config)
        {
            _config = config.Value;
        }

        public async Task<Cliente> GetClientes(Guid uuid)
        {
            return await _config.PolarisClienteConfig.Url
                .AppendPathSegment(_config.PolarisClienteConfig.Endpoints.Cliente)
                .AppendPathSegment(uuid)
                .GetJsonAsync<Cliente>();
        }

        public async Task<RetornoClienteViewModel> GetClienteAluguel(Guid uuid)
        {
            return await _config.PolarisClienteConfig.Url
                .AppendPathSegment(_config.PolarisClienteConfig.Endpoints.Cliente)
                .AppendPathSegment(_config.PolarisClienteConfig.Endpoints.GetClienteAluguel)
                .AppendPathSegment(uuid)
                .GetJsonAsync<RetornoClienteViewModel>();
        }
    }
}
