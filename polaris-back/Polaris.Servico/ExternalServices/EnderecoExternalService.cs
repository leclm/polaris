using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Options;
using Polaris.Servico.Configs;
using Polaris.Servico.Models;
using Polaris.Servico.ViewModels;

namespace Polaris.Servico.ExternalServices
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
                .AppendPathSegment(_config.PolarisEnderecoConfig.Endpoints.GetEndereco)
                .AppendPathSegment(uuid)
                .GetJsonAsync<Endereco>();
        }

        public async Task<Guid> PostEnderecos(CadastroEnderecoViewModel endereco)
        {
            return await _config.PolarisEnderecoConfig.Url
                .AppendPathSegment(_config.PolarisEnderecoConfig.Endpoints.GetEndereco)
                .PostJsonAsync(endereco)
                .ReceiveJson<Guid>();
        }

        public async Task<Guid> PutEnderecos(AtualizaEnderecoViewModel endereco)
        {
            return await _config.PolarisEnderecoConfig.Url
                .AppendPathSegment(_config.PolarisEnderecoConfig.Endpoints.GetEndereco)
                .PutJsonAsync(endereco)
                .ReceiveJson<Guid>();
        }
    }
}
