using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Polaris.Servico.Models
{
    [Table("Servicos")]
    public class Servico
    {
        [Key]
        public int ServicoId { get; set; }
        [Required]
        [NotNull]
        [MaxLength(100)]
        public string? Nome { get; set; }
        public ICollection<Terceirizado>? Terceirizados { get; set; }
    }
}
