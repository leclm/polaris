using Polaris.Usuario.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Polaris.Usuario.ViewModels
{
    public class RetornoGerenteViewModel
    {
        public int GerenteId { get; set; }
        public Guid GerenteUuid { get; set; }
        public string Cnpj { get; set; }
        public string Empresa { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public bool Status { get; set; }
        public RetornoEnderecoViewModel Endereco { get; set; }
        public RetornoLoginViewModel Login { get; set; }
    }
}
