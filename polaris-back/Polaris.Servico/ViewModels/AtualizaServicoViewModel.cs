using Polaris.Servico.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Polaris.Servico.ViewModels
{
    public class AtualizaServicoViewModel
    {
        public Guid ServicoUuid { get; set; }
        public string? Nome { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public ICollection<Terceirizado>? Terceirizados { get; set; }
    }
}
