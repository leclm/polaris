using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Options;
using Polaris.Aluguel.Configs;
using Polaris.Aluguel.ViewModels;

namespace Polaris.Aluguel.ExternalServices
{
    public class ConteinerExternalService : IConteinerExternalService
    {
        private readonly ExternalConfigs _config;
        public ConteinerExternalService(IOptions<ExternalConfigs> config)
        {
            _config = config.Value;
        }

        public async Task<RetornoConteinerViewModel> GetConteineres(Guid uuid, string token)
        {
            return await _config.PolarisConteinerConfig.Url
                .AppendPathSegment(_config.PolarisConteinerConfig.Endpoints.Conteineres)
                .AppendPathSegment(uuid)
                .WithHeader("Authorization", token)
                .GetJsonAsync<RetornoConteinerViewModel> ();
        }

        public async Task<IEnumerable<RetornoConteinerViewModel>> GetConteineresAluguel(Guid uuid, string token)
        {
            return await _config.PolarisConteinerConfig.Url
                .AppendPathSegment(_config.PolarisConteinerConfig.Endpoints.Conteineres)
                .AppendPathSegment(_config.PolarisConteinerConfig.Endpoints.GetConteineresAluguel)
                .AppendPathSegment(uuid)
                .WithHeader("Authorization", token)
                .GetJsonAsync<IEnumerable<RetornoConteinerViewModel>>();
        }

        public void AlterarDisponibilidadeConteiner(Guid uuid, int estado, string token)
        {
            _config.PolarisConteinerConfig.Url
                .AppendPathSegment(_config.PolarisConteinerConfig.Endpoints.Conteineres)
                .AppendPathSegment(_config.PolarisConteinerConfig.Endpoints.AlterarDisponibilidadeConteiner)
                .AppendPathSegment(uuid)
                .AppendPathSegment(estado)
                .WithHeader("Authorization", token)
                .SendAsync(HttpMethod.Put);
        }
    }
}
