using Polaris.Aluguel.Enums;

namespace Polaris.Aluguel.ViewModels
{
    public class RetornoAluguelViewModel
    {
        public Guid AluguelUuid { get; set; }
        public EstadoAluguel EstadoAluguel { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataDevolucao { get; set; }
        public TipoLocacao TipoLocacao { get; set; }
        public double Desconto { get; set; }
        public double ValorTotalAluguel { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool Status { get; set; }


        public BuscaClienteViewModel? Cliente { get; set; }

        public RetornoEnderecoViewModel? Endereco { get; set; }

        public IEnumerable<BuscaConteinerViewModel>? Conteineres { get; set; }
    }
}
