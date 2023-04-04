using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Polaris.Servico.ViewModels
{
    public class AtualizaTerceirizadoViewModel
    {
        public Guid TerceirizadoUuid { get; set; }
        public string? Cnpj { get; set; }
        public string? Empresa { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public ICollection<Models.Servico>? Servicos { get; set; }
    }
}
