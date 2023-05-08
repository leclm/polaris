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

        public async Task<Endereco> GetEnderecos(Guid uuid)
        {
            return await _config.PolarisEnderecoConfig.Url
                .AppendPathSegment(_config.PolarisEnderecoConfig.Endpoints.Endereco)
                .AppendPathSegment(uuid)
                .GetJsonAsync<Endereco>();
        }

        public async Task<Endereco> GetEnderecoCliente(Guid uuid)
        {
            return await _config.PolarisEnderecoConfig.Url
                .AppendPathSegment(_config.PolarisEnderecoConfig.Endpoints.Endereco)
                .AppendPathSegment(_config.PolarisEnderecoConfig.Endpoints.GetEnderecoCliente)
                .AppendPathSegment(uuid)
                .GetJsonAsync<Endereco>();
        }

        public async Task<Guid> PostEnderecos(CadastroEnderecoViewModel endereco)
        {
            return await _config.PolarisEnderecoConfig.Url
                .AppendPathSegment(_config.PolarisEnderecoConfig.Endpoints.Endereco)
                .PostJsonAsync(endereco)
                .ReceiveJson<Guid>();
        }

        public async Task PutEnderecos(AtualizaEnderecoViewModel endereco)
        {
            await _config.PolarisEnderecoConfig.Url
                .AppendPathSegment(_config.PolarisEnderecoConfig.Endpoints.Endereco)
                .PutJsonAsync(endereco);
        }
    }
}
