﻿namespace Polaris.Usuario.ViewModels
{
    public class RetornoLoginViewModel
    {
        public Guid LoginUuid { get; set; }
        public string? Usuario { get; set; }
        public bool Status { get; set; }
        public bool IsGerente { get; set; }
        public string Token { get; set; }
    }
}
