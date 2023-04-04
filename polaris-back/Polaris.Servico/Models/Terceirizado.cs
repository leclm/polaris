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
        public Guid TerceirizadoUuid { get; set; }
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
        [Required]
        [NotNull]
        [ForeignKey("Endereco")]
        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }
        public bool Status { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public ICollection<Servico>? Servicos { get; set; }
    }
}
