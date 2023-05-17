using Polaris.Endereco.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Polaris.Endereco.Models
{
    [Table("Conteiner")]

    public class Conteiner
    {
        [Key]
        public int ConteinerId { get; set; }
        public Guid ConteinerUuid { get; set; }
        public int Codigo { get; set; }
        public String Fabricacao { get; set; }
        [MinLength(1, ErrorMessage = "Erro. Digite um fabricante.")]
        [MaxLength(100, ErrorMessage = "Erro. Excedeu o número de caracteres.")]
        [NotNull]
        [Required]
        public string? Fabricante { get; set; }
        [MinLength(1, ErrorMessage = "Erro. Digite um material.")]
        [MaxLength(100, ErrorMessage = "Erro. Excedeu o número de caracteres.")]
        [NotNull]
        [Required]
        public string? Material { get; set; }
        [MinLength(1, ErrorMessage = "Erro. Digite uma cor.")]
        [MaxLength(100, ErrorMessage = "Erro. Excedeu o número de caracteres.")]
        [NotNull]
        [Required]
        public string? Cor { get; set; }
        public EstadoConteiner Estado { get; set; }
        public bool Status { get; set; }

        [ForeignKey("CategoriaConteiner")]
        public int CategoriaConteinerId { get; set; }
        public virtual CategoriaConteiner? CategoriaConteiner { get; set; }

        [ForeignKey("TipoConteiner")]
        public int TipoConteinerId { get; set; }

        public virtual TipoConteiner? TipoConteiner { get; set; }
    }
}
