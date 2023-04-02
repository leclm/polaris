using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Polaris.Endereco.Models
{
    [Table("Enderecos")]
    public class Endereco
    {
        [Key]
        public int EnderecoId { get; set; }
        [Required]
        [MaxLength(45)]
        public string? Cep { get; set; }
        [Required]
        [NotNull]
        [MaxLength(100)]
        public string? Cidade { get; set; }
        [Required]
        [NotNull]
        [MaxLength(45)]
        public string? Estado { get; set; }
        [Required]
        [NotNull]
        [MaxLength(200)]
        public string? Logradouro { get; set; }
        public string? Complemento { get; set; }
        public int Numero { get; set; }
        public bool Status { get; set; }
    }
}
