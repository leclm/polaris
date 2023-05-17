using Polaris.Aluguel.Enums;

namespace Polaris.Aluguel.ViewModels
{
    public class CadastroAluguelViewModel
    {
        public DateTime DataInicio { get; set; }
        public DateTime DataDevolucao { get; set; }
        public TipoLocacao TipoLocacao { get; set; }
        public double Desconto { get; set; }
        public double ValorTotalAluguel { get; set; }

        public RetornoClienteViewModel? Cliente { get; set; }

        public CadastroEnderecoViewModel? Endereco { get; set; }

        public IEnumerable<RetornoConteinerViewModel>? Conteineres { get; set; }
    }
}
