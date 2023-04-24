﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Polaris.Conteiner.Models
{
    [Table("Servicos")]
    public class Servico
    {
        [Key]
        public int ServicoId { get; set; }
        public Guid ServicoUuid { get; set; }
        [MinLength(1, ErrorMessage = "Erro. Digite um serviço.")]
        [MaxLength(100, ErrorMessage = "Erro. Excedeu o número de caracteres.")]
        [NotNull]
        [Required]
        public string? Nome { get; set; }
        public bool Status { get; set; }
        public virtual IEnumerable<Terceirizado>? Terceirizados { get; set; }
    }
}
