using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Polaris.Aluguel.Models
{
    [Table("Cliente")]

    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }
        public Guid ClienteUuid { get; set; }
        [MinLength(1, ErrorMessage = "Erro. Digite um CPF.")]
        [MaxLength(11, ErrorMessage = " Erro. CPF inválido.")]
        [NotNull]
        [Required]
        public string? Cpf { get; set; }
        [MinLength(1, ErrorMessage = "Erro. Digite um nome.")]
        [MaxLength(100, ErrorMessage = "Erro. Excedeu o número de caracteres.")]
        [NotNull]
        [Required]
        public string? Nome { get; set; }
        [MinLength(1, ErrorMessage = "Erro. Digite um sobrenome.")]
        [MaxLength(100, ErrorMessage = "Erro. Excedeu o número de caracteres.")]
        [NotNull]
        [Required]
        public string? Sobrenome { get; set; }
        [NotNull]
        [Required]
        public DateOnly DataNascimento { get; set; }
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
        public bool Status { get; set; }

        [Required]
        [NotNull]
        [ForeignKey("Endereco")]
        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}
