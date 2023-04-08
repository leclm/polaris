namespace Polaris.Servico.Configs
{
    public class ExternalConfigs
    {
        public PolarisEnderecoConfig PolarisEnderecoConfig { get; set; }
    }

    public class PolarisEnderecoConfig
    {
        public string Url { get; set; }
        public Endpoints Endpoints { get; set; }
    }

    public class Endpoints
    {
        public string GetEndereco { get; set; }
    }
}
