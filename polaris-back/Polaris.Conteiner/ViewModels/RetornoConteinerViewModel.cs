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
        public string? Fabricante { get; set; }
        public string? Material { get; set; }
        public EstadoConteiner Estado { get; set; }
        public string? Cor { get; set; }
        public bool Status { get; set; }
        public RetornoCategoriaConteinerViewModel CategoriaConteiner { get; set; }
        public RetornoTipoConteinerViewModel TipoConteiner { get; set; }

    }
}
