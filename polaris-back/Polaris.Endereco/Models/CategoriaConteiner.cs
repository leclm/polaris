using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Polaris.Endereco.Models
{
    [Table("CategoriasConteineres")]
    public class CategoriaConteiner
    {
        [Key]
        public int CategoriaConteinerId { get; set; }
        public Guid CategoriaConteinerUuid { get; set; }
        [MinLength(1, ErrorMessage = "Erro. Digite uma categoria.")]
        [MaxLength(100, ErrorMessage = "Erro. Excedeu o número de caracteres.")]
        [NotNull]
        [Required]
        public string? Nome { get; set; }
        public bool Status { get; set; }
    }
}
