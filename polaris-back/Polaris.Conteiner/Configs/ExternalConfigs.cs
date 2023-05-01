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
        public string Terceirizados { get; set; }
        public string Servicos { get; set; }
        public string BuscarTerceirizadoPrestacaoServico { get; set; }
        public string BuscarServicoPrestacaoServico { get; set; }
    }
}
