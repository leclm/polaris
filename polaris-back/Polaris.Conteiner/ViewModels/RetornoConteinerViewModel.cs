﻿using Polaris.Conteiner.Enums;
using Polaris.Conteiner.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Polaris.Conteiner.ViewModels
{
    public class RetornoConteinerViewModel
    {
        public Guid ConteinerUuid { get; set; }
        public int Codigo { get; set; }
        public String Fabricacao { get; set; }
        [MinLength(1, ErrorMessage = "Erro. Digite um fabricante.")]
        [MaxLength(100, ErrorMessage = "Erro. Excedeu o número de caracteres.")]
        [NotNull]
        [Required]
        public string? Fabricante { get; set; }
        [MinLength(1, ErrorMessage = "Erro. Digite um material.")]
        [MaxLength(100, ErrorMessage = "Erro. Excedeu o número de caracteres.")]
        [NotNull]
        [Required]
        public string? Material { get; set; }
        public EstadoConteiner Estado { get; set; }
        [MinLength(1, ErrorMessage = "Erro. Digite uma cor.")]
        [MaxLength(100, ErrorMessage = "Erro. Excedeu o número de caracteres.")]
        [NotNull]
        [Required]
        public string? Cor { get; set; }
        public bool Status { get; set; }
        public RetornoCategoriaConteinerViewModel CategoriaConteiner { get; set; }
        public RetornoTipoConteinerViewModel TipoConteiner { get; set; }

    }
}
