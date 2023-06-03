﻿using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Options;
using Polaris.Conteiner.Configs;
using Polaris.Conteiner.ViewModels;

namespace Polaris.Conteiner.ExternalServices
{
    public class ServicoExternalService : IServicoExternalService
    {
        private readonly ExternalConfigs _config;
        public ServicoExternalService(IOptions<ExternalConfigs> config)
        {
            _config = config.Value;
        }

        public async Task<RetornoTerceirizadoViewModel> GetTerceirizado(Guid uuid, string token)
        {
            return await _config.PolarisServicoConfig.Url
                .AppendPathSegment(_config.PolarisServicoConfig.Endpoints.Terceirizados)
                .AppendPathSegment(_config.PolarisServicoConfig.Endpoints.BuscarTerceirizadoPrestacaoServico)
                .AppendPathSegment(uuid)
                .WithHeader("Authorization", token)
                .GetJsonAsync<RetornoTerceirizadoViewModel>();
        }

        public async Task<BuscaServicoViewModel> GetServico(Guid uuid, string token)
        {
            return await _config.PolarisServicoConfig.Url
                .AppendPathSegment(_config.PolarisServicoConfig.Endpoints.Servicos)
                .AppendPathSegment(_config.PolarisServicoConfig.Endpoints.BuscarServicoPrestacaoServico)
                .AppendPathSegment(uuid)
                .WithHeader("Authorization", token)
                .GetJsonAsync<BuscaServicoViewModel>();
        }
    }
}
