﻿using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Polaris.Conteiner.ViewModels
{
    public class BuscaTipoViewModel
    {
        public Guid TipoConteinerUuid { get; set; }
        [MinLength(1, ErrorMessage = "Erro. Digite um tipo de conteiner.")]
        [MaxLength(100, ErrorMessage = "Erro. Excedeu o número de caracteres.")]
        [NotNull]
        [Required]
        public string? Nome { get; set; }
    }
}