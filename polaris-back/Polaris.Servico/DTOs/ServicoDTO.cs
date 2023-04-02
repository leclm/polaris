using Polaris.Servico.Models;

namespace Polaris.Servico.DTOs
{
    public class ServicoDTO
    {
        public string? Nome { get; set; }
        public ICollection<Terceirizado>? Terceirizados { get; set; }
    }
}
