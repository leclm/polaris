using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Polaris.Usuario.ViewModels
{
    public class RetornoEnderecoViewModel
    {
        public Guid EnderecoUuid { get; set; }
        public string? Cep { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? Logradouro { get; set; }
        public string? Complemento { get; set; }
        public int Numero { get; set; }
        public bool Status { get; set; }
    }
}
