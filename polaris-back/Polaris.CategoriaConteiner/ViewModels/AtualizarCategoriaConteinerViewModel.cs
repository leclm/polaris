﻿using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Polaris.CategoriaConteiner.ViewModels
{
    public class AtualizarCategoriaConteinerViewModel
    {
        public Guid CategoriaConteinerUuid { get; set; }
        [MinLength(1, ErrorMessage = "Erro. Digite uma categoria.")]
        [MaxLength(100, ErrorMessage = "Erro. Excedeu o número de caracteres.")]
        [NotNull]
        [Required]
        public string? Nome { get; set; }
    }
}