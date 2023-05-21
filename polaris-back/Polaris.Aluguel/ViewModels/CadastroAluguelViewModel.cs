using Polaris.Aluguel.Enums;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Polaris.Aluguel.ViewModels
{
    public class CadastroAluguelViewModel
    {
        [Required]
        [NotNull]
        public DateTime DataInicio { get; set; }
        [Required]
        [NotNull]
        public DateTime DataDevolucao { get; set; }
        [Required]
        [NotNull]
        public TipoLocacao TipoLocacao { get; set; }
        public double Desconto { get; set; }
        [NotNull]
        [Required]
        public double ValorTotalAluguel { get; set; }
        [Required]
        [NotNull]
        public Guid? ClienteUuid { get; set; }
        [Required]
        [NotNull]
        public CadastroEnderecoViewModel? Endereco { get; set; }
        [Required]
        [NotNull]
        public IEnumerable<Guid>? ConteineresUuid { get; set; }
    }
}
