﻿using Polaris.Servico.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Polaris.Servico.ViewModels
{
    public class RetornoTerceirizadoViewModel
    {
        public Guid TerceirizadoUuid { get; set; }
        public string? Cnpj { get; set; }
        public string? Empresa { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public bool Status { get; set; }
        public RetornoEnderecoViewModel? Endereco { get; set; }

        public IEnumerable<BuscaServicoViewModel>? Servicos { get; set; }
    }
}
