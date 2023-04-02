using System.ComponentModel.DataAnnotations;

namespace Polaris.Endereco.DTOs
{
    public class EnderecoDTO
    {
        public int EnderecoId { get; set; }
        public string? Cep { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? Logradouro { get; set; }
        public string? Complemento { get; set; }
        public int Numero { get; set; }
        public bool Status { get; set; }
    }
}
