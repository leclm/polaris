﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Polaris.Endereco.Models
{
    [Table("Gerente")]

    public class Gerente
    {
        [Key]
        public int GerenteId { get; set; }
        public Guid GerenteUuid { get; set; }
        [MinLength(1, ErrorMessage = "Erro. Digite um CNPJ.")]
        [MaxLength(18, ErrorMessage = " Erro. CNPJ inválido.")]
        [NotNull]
        [Required]
        public string Cnpj { get; set; }
        [MinLength(1, ErrorMessage = "Erro. Digite uma empresa.")]
        [MaxLength(100, ErrorMessage = "Erro. Excedeu o número de caracteres.")]
        [NotNull]
        [Required]
        public string Empresa { get; set; }
        [MinLength(1, ErrorMessage = "Erro. Digite um e-mail.")]
        [MaxLength(45, ErrorMessage = "Erro. Excedeu o número de caracteres.")]
        [NotNull]
        [Required]
        public string Email { get; set; }
        [MinLength(1, ErrorMessage = "Erro. Digite um telefone.")]
        [MaxLength(45, ErrorMessage = "Erro. Excedeu o número de caracteres.")]
        [NotNull]
        [Required]
        public string Telefone { get; set; }
        public bool Status { get; set; }
        public bool JaContatado { get; set; }

        [Required]
        [NotNull]
        [ForeignKey("Endereco")]
        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }

        [ForeignKey("Login")]
        public int LoginId { get; set; }
        public virtual Login? Login { get; set; }
    }
}
