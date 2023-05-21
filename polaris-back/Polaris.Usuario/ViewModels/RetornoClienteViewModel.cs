using Polaris.Usuario.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Polaris.Usuario.ViewModels
{
    public class RetornoClienteViewModel
    {
        public Guid ClienteUuid { get; set; }
        public string? Cpf { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public bool Status { get; set; }
        public RetornoEnderecoViewModel Endereco { get; set; }
        public RetornoLoginViewModel Login { get; set; }
    }
}
