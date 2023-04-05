using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Polaris.Servico.Models
{
    [Table("Enderecos")]
    public class Endereco
    {
        [Key]
        public int EnderecoId { get; set; }
        [Required]
        public Guid EnderecoUuid { get; set; }
        [MinLength(1, ErrorMessage = "Erro. Digite um CEP.")]
        [MaxLength(45, ErrorMessage = "Erro. Excedeu o número de caracteres.")]
        [NotNull]
        [Required]
        public string? Cep { get; set; }
        [MinLength(1, ErrorMessage = "Erro. Digite uma cidade.")]
        [MaxLength(100, ErrorMessage = "Erro. Excedeu o número de caracteres.")]
        [NotNull]
        [Required]
        public string? Cidade { get; set; }
        [MinLength(1, ErrorMessage = "Erro. Digite um estado.")]
        [MaxLength(45, ErrorMessage = "Erro. Excedeu o número de caracteres.")]
        [NotNull]
        [Required]
        public string? Estado { get; set; }
        [MinLength(1, ErrorMessage = "Erro. Digite um logradouro.")]
        [MaxLength(200, ErrorMessage = "Erro. Excedeu o número de caracteres.")]
        [NotNull]
        [Required]
        public string? Logradouro { get; set; }
        public string? Complemento { get; set; }
        public int Numero { get; set; }
        public bool Status { get; set; }
    }
}
