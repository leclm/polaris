using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Options;
using Polaris.Aluguel.Configs;
using Polaris.Aluguel.Models;

namespace Polaris.Aluguel.ExternalServices
{
    public class ConteinerExternalService : IConteinerExternalService
    {
        private readonly ExternalConfigs _config;
        public ConteinerExternalService(IOptions<ExternalConfigs> config)
        {
            _config = config.Value;
        }

        public async Task<IEnumerable<Conteiner>> GetConteineres(Guid uuid)
        {
            return await _config.PolarisConteinerConfig.Url
                .AppendPathSegment(_config.PolarisConteinerConfig.Endpoints.Conteineres)
                .AppendPathSegment(uuid)
                .GetJsonAsync<IEnumerable<Models.Conteiner>> ();
        }

        public async Task<IEnumerable<Conteiner>> GetConteineresAluguel(Guid uuid)
        {
            return await _config.PolarisConteinerConfig.Url
                .AppendPathSegment(_config.PolarisConteinerConfig.Endpoints.Conteineres)
                .AppendPathSegment(_config.PolarisConteinerConfig.Endpoints.GetConteineresAluguel)
                .AppendPathSegment(uuid)
                .GetJsonAsync<IEnumerable<Models.Conteiner>>();
        }
    }
}
