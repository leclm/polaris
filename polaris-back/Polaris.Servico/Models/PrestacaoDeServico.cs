﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Polaris.Conteiner.Enums;

namespace Polaris.Servico.Models
{
    [Table("PrestacaoDeServico")]
    public class PrestacaoDeServico
    {
        [Key]
        public int PrestacaoDeServicoId { get; set; }
        public Guid PrestacaoDeServicoUuid { get; set; }
        [NotNull]
        [Required]
        public ServicoStatus Status { get; set; }
        [NotNull]
        [Required]
        public DateTime DataProcedimento { get; set; }
        [MaxLength(200, ErrorMessage = "Erro. Excedeu o número de caracteres.")]
        public string? Comentario { get; set; }
        [Required]
        [NotNull]
        [ForeignKey("Conteiner")]
        public int ConteinerId { get; set; }
        public virtual Conteiner Conteiner { get; set; }
        [Required]
        [NotNull]
        [ForeignKey("Tercerizado")]
        public int TerceirizadoId { get; set; }
        public virtual Terceirizado Tercerizado { get; set; }
        [Required]
        [NotNull]
        [ForeignKey("Servico")]
        public int ServicoId { get; set; }
        public virtual Servico Servico { get; set; }
    }
}