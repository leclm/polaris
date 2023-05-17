namespace Polaris.Aluguel.Configs
{
    public class ExternalConfigs
    {
        public PolarisEnderecoConfig PolarisEnderecoConfig { get; set; }
        public PolarisClienteConfig PolarisClienteConfig { get; set; }
        public PolarisConteinerConfig PolarisConteinerConfig { get; set; }
    }

    public class PolarisEnderecoConfig
    {
        public string Url { get; set; }
        public Endpoints Endpoints { get; set; }
    }

    public class PolarisClienteConfig
    {
        public string Url { get; set; }
        public Endpoints Endpoints { get; set; }
    }

    public class PolarisConteinerConfig
    {
        public string Url { get; set; }
        public Endpoints Endpoints { get; set; }
    }
    public class Endpoints
    {
        public string Endereco { get; set; }
        public string GetEnderecoAluguel { get; set; }

        public string Cliente { get; set; }
        public string GetClienteAluguel { get; set; }

        public IEnumerable<string> Conteineres { get; set; }
        public IEnumerable<string> GetConteineresAluguel { get; set; }
    }
}
