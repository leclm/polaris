using NuGet.Protocol.Plugins;
using Polaris.Aluguel.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Polaris.Aluguel.Models
{
    [Table("Aluguel")]
    public class Aluguel
    {
        [Key]
        public int AluguelId { get; set; }
        public Guid AluguelUuid { get; set; }
        [NotNull]
        [Required]
        public EstadoAluguel EstadoAluguel { get; set; }
        [NotNull]
        [Required]
        public DateTime DataInicio { get; set; }
        [NotNull]
        [Required]
        public DateTime DataDevolucao { get; set; }
        [NotNull]
        [Required]
        public TipoLocacao TipoLocacao { get; set; }
        [NotNull]
        public double Desconto { get; set; }
        [NotNull]
        [Required]
        public double ValorTotalAluguel { get; set; }
        [NotNull]
        [Required]
        public bool Status { get; set; }

        [NotNull]
        [Required]
        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }
        public virtual Cliente? Cliente { get; set; }

        [Required]
        [NotNull]
        [ForeignKey("Endereco")]
        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<Conteiner>? Conteineres { get; set; }
    }
}
