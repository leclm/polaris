namespace Polaris.Conteiner.Configs
{
    public class ExternalConfigs
    {
        public PolarisServicoConfig PolarisServicoConfig { get; set; }
    }

    public class PolarisServicoConfig
    {
        public string Url { get; set; }
        public Endpoints Endpoints { get; set; }
    }

    public class Endpoints
    {
        public string Servico { get; set; }
        public string GetServicoConteiner { get; set; }
    }
}
