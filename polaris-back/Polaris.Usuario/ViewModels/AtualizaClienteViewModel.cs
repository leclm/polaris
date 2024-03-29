﻿using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Polaris.Usuario.ViewModels
{
    public class AtualizaClienteViewModel
    {
        public Guid ClienteUuid { get; set; }
        [MinLength(1, ErrorMessage = "Erro. Digite um nome.")]
        [MaxLength(100, ErrorMessage = "Erro. Excedeu o número de caracteres.")]
        [NotNull]
        [Required]
        public string? Nome { get; set; }
        [MinLength(1, ErrorMessage = "Erro. Digite um sobrenome.")]
        [MaxLength(100, ErrorMessage = "Erro. Excedeu o número de caracteres.")]
        [NotNull]
        [Required]
        public string? Sobrenome { get; set; }
        [NotNull]
        [Required]
        public DateTime DataNascimento { get; set; }
        [MinLength(1, ErrorMessage = "Erro. Digite um telefone.")]
        [MaxLength(45, ErrorMessage = "Erro. Excedeu o número de caracteres.")]
        [NotNull]
        [Required]
        public string? Telefone { get; set; }
        [NotNull]
        [Required]
        public AtualizaEnderecoViewModel? Endereco { get; set; }
        //public AtualizaLoginViewModel Login { get; set; }
    }
}
