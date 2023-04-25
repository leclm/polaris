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
            Servicos = new List<Servico>();
        }

        [Key]
        public int TerceirizadoId { get; set; }
        public Guid TerceirizadoUuid { get; set; }
        [MinLength(1, ErrorMessage = "Erro. Digite um CNPJ.")]
        [MaxLength(18, ErrorMessage = " Erro. CNPJ inválido.")]
        [NotNull]
        [Required]
        public string? Cnpj { get; set; }
        [MinLength(1, ErrorMessage = "Erro. Digite uma empresa.")]
        [MaxLength(100, ErrorMessage = "Erro. Excedeu o número de caracteres.")]
        [NotNull]
        [Required]
        public string? Empresa { get; set; }
        [MinLength(1, ErrorMessage = "Erro. Digite um e-mail.")]
        [MaxLength(45, ErrorMessage = "Erro. Excedeu o número de caracteres.")]
        [NotNull]
        [Required]
        public string? Email { get; set; }
        [MinLength(1, ErrorMessage = "Erro. Digite um telefone.")]
        [MaxLength(45, ErrorMessage = "Erro. Excedeu o número de caracteres.")]
        [NotNull]
        [Required]
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
