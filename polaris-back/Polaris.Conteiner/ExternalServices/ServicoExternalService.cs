using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Options;
using Polaris.Conteiner.Configs;

namespace Polaris.Conteiner.ExternalServices
{
    public class ServicoExternalService : IServicoExternalService
    {
        private readonly ExternalConfigs _config;
        public ServicoExternalService(IOptions<ExternalConfigs> config)
        {
            _config = config.Value;
        }

        public async Task<Models.Servico> GetServicos(Guid uuid)
        {
            return await _config.PolarisServicoConfig.Url
                .AppendPathSegment(_config.PolarisServicoConfig.Endpoints.Servico)
                .AppendPathSegment(uuid)
                .GetJsonAsync<Models.Servico>();
        }
    }
}
