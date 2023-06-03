using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Options;
using Polaris.Usuario.Configs;
using Polaris.Usuario.Models;
using Polaris.Usuario.ViewModels;

namespace Polaris.Usuario.ExternalServices
{
    public class EnderecoExternalService : IEnderecoExternalService
    {
        private readonly ExternalConfigs _config;
        public EnderecoExternalService(IOptions<ExternalConfigs> config)
        {
            _config = config.Value;
        }

        public async Task<Endereco> GetEnderecos(Guid uuid, string token)
        {
            return await _config.PolarisEnderecoConfig.Url
                .AppendPathSegment(_config.PolarisEnderecoConfig.Endpoints.Endereco)
                .AppendPathSegment(uuid)
                .WithHeader("Authorization", token)
                .GetJsonAsync<Endereco>();
        }

        public async Task<Endereco> GetEnderecoCliente(Guid uuid, string token)
        {
            return await _config.PolarisEnderecoConfig.Url
                .AppendPathSegment(_config.PolarisEnderecoConfig.Endpoints.Endereco)
                .AppendPathSegment(_config.PolarisEnderecoConfig.Endpoints.GetEnderecoCliente)
                .AppendPathSegment(uuid)
                .WithHeader("Authorization", token)
                .GetJsonAsync<Endereco>();
        }
        public async Task<Endereco> GetEnderecoGerente(Guid uuid, string token)
        {
            return await _config.PolarisEnderecoConfig.Url
                .AppendPathSegment(_config.PolarisEnderecoConfig.Endpoints.Endereco)
                .AppendPathSegment(_config.PolarisEnderecoConfig.Endpoints.GetEnderecoGerente)
                .AppendPathSegment(uuid)
                .WithHeader("Authorization", token)
                .GetJsonAsync<Endereco>();
        }

        public async Task<Guid> PostEnderecos(CadastroEnderecoViewModel endereco, string token)
        {
            return await _config.PolarisEnderecoConfig.Url
                .AppendPathSegment(_config.PolarisEnderecoConfig.Endpoints.Endereco)
                .WithHeader("Authorization", token)
                .PostJsonAsync(endereco)
                .ReceiveJson<Guid>();
        }

        public async Task PutEnderecos(AtualizaEnderecoViewModel endereco, string token)
        {
            await _config.PolarisEnderecoConfig.Url
                .AppendPathSegment(_config.PolarisEnderecoConfig.Endpoints.Endereco)
                .WithHeader("Authorization", token)
                .PutJsonAsync(endereco);
        }
    }
}
