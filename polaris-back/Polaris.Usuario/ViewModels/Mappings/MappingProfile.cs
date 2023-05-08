using AutoMapper;

namespace Polaris.Usuario.ViewModels.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.Endereco, CadastroEnderecoViewModel>().ReverseMap();
            CreateMap<Models.Endereco, RetornoEnderecoViewModel>().ReverseMap();
            CreateMap<Models.Endereco, AtualizaEnderecoViewModel>().ReverseMap();

            CreateMap<Models.Cliente, CadastroClienteViewModel>().ReverseMap();
            CreateMap<Models.Cliente, RetornoClienteViewModel>().ReverseMap();
            CreateMap<Models.Cliente, AtualizaClienteViewModel>().ReverseMap();

            CreateMap<Models.Login, CadastroLoginViewModel>().ReverseMap();
            CreateMap<Models.Login, RetornoLoginViewModel>().ReverseMap();
            CreateMap<Models.Login, AtualizaLoginViewModel>().ReverseMap();

            CreateMap<Models.Login, AlteraSenha>().ReverseMap();
        }
    }
}
