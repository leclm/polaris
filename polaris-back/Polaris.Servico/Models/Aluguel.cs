using Polaris.Servico.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Polaris.Servico.Models
{
    [Table("Aluguel")]
    public class Aluguel
    {
        [Key]
        public int AluguelId { get; set; }
        public Guid AluguelUuid { get; set; }
        public EstadoAluguel EstadoAluguel { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataDevolucao { get; set; }
        [NotNull]
        [Required]
        public TipoLocacao TipoLocacao { get; set; }
        public double Desconto { get; set; }
        [NotNull]
        [Required]
        public double ValorTotalAluguel { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool Status { get; set; }

        //[ForeignKey("Cliente")]
        //public int ClienteId { get; set; }
        //public virtual Cliente? Cliente { get; set; }

        [Required]
        [NotNull]
        [ForeignKey("Endereco")]
        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<Conteiner> Conteineres { get; set; }
    }
}
