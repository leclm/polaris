﻿using Polaris.Endereco.DTOs;

namespace Polaris.Endereco.Services
{
    public interface IEnderecosService
    {
        Task<IEnumerable<RetornoEnderecoViewModel>> GetEnderecos();
        Task<RetornoEnderecoViewModel> GetEndereco(Guid uuid);
        Task<Guid> PostEndereco(CadastroEnderecoViewModel enderecoDto);
        Task PutEndereco(AtualizaEnderecoViewModel enderecoDto);
        Task AlterarStatus(Guid uuid, bool status);
    }
}
