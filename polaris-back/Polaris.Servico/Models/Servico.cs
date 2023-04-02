using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;

namespace Polaris.Servico.Models
{
    [Table("Servicos")]
    public class Servico
    {
        [Key]
        public int ServicoId { get; set; }
        [Required]
        [NotNull]
        [MaxLength(100)]
        public string? Nome { get; set; }
        public bool Status { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public ICollection<Terceirizado>? Terceirizados { get; set; }
    }
}
