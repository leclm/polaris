using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Polaris.Servico.Models
{
    [Table("Terceirizado")]
    public class Terceirizado
    {
        public Terceirizado()
        {
            Servicos = new Collection<Servico>();
        }

        [Key]
        public int TerceirizadoId { get; set; }
        [Required]
        [NotNull]
        [MaxLength(45)]
        public string? Cnpj { get; set; }
        [Required]
        [NotNull]
        [MaxLength(100)]
        public string? Empresa { get; set; }
        [Required]
        [NotNull]
        [MaxLength(45)]
        public string? Email { get; set; }
        [Required]
        [NotNull]
        [MaxLength(45)]
        public string? Telefone { get; set; }

        public ICollection<Servico>? Servicos { get; set; }
    }
}
