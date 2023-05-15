using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Polaris.Aluguel.Models
{
    [Table("TiposConteineres")]
    public class TipoConteiner
    {
        [Key]
        public int TipoConteineroId { get; set; }
        public Guid TipoConteinerUuid { get; set; }
        [MinLength(1, ErrorMessage = "Erro. Digite um tipo de conteiner.")]
        [MaxLength(100, ErrorMessage = "Erro. Excedeu o número de caracteres.")]
        [NotNull]
        [Required]
        public string? Nome { get; set; }
        [NotNull]
        [Required]
        public double Largura { get; set; }
        [NotNull]
        [Required]
        public double Comprimento { get; set; }
        [NotNull]
        [Required]
        public double Volume { get; set; }
        [NotNull]
        [Required]
        public double PesoMaximo { get; set; }
        [NotNull]
        [Required]
        public double Altura { get; set; }
        [NotNull]
        [Required]
        public double ValorDiaria { get; set; }
        [NotNull]
        [Required]
        public double ValorMensal { get; set; }
        public bool Status { get; set; }
    }
}
