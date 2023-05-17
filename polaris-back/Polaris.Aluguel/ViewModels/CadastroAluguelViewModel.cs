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

        public Guid? Cliente { get; set; }

        public CadastroEnderecoViewModel? Endereco { get; set; }

        public IEnumerable<Guid>? Conteineres { get; set; }
    }
}
