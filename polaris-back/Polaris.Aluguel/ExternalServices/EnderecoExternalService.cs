using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Options;
using Polaris.Aluguel.Configs;
using Polaris.Aluguel.Models;
using Polaris.Aluguel.ViewModels;

namespace Polaris.Aluguel.ExternalServices
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
        

        public async Task<Endereco> GetEnderecoAluguel(Guid uuid)
        {
            return await _config.PolarisEnderecoConfig.Url
                .AppendPathSegment(_config.PolarisEnderecoConfig.Endpoints.Endereco)
                .AppendPathSegment(_config.PolarisEnderecoConfig.Endpoints.GetEnderecoAluguel)
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
