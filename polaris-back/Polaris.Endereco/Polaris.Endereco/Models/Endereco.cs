using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Polaris.Endereco.Models
{
    [Table("Enderecos")]
    public class Endereco
    {
        [Key]
        public int EnderecoId { get; set; }
        [Required]
        [StringLength(45)]
        public string? Cep { get; set; }
        [Required]
        [StringLength(100)]
        public string? Cidade { get; set; }
        [Required]
        [StringLength(45)]
        public string? Estado { get; set; }
        [Required]
        [StringLength(200)]
        public string? Logradouro { get; set; }
        public string? Complemento { get; set; }
        public int Numero { get; set; }
    }
}
