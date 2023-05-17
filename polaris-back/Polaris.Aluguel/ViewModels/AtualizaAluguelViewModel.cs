using Polaris.Aluguel.Enums;

namespace Polaris.Aluguel.ViewModels
{
    public class AtualizaAluguelViewModel
    {
        public Guid AluguelUuid { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataDevolucao { get; set; }
        public TipoLocacao TipoLocacao { get; set; }
        public double Desconto { get; set; }
        public double ValorTotalAluguel { get; set; }
    }
}
