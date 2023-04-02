using AutoMapper;

namespace Polaris.Endereco.DTOs.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.Endereco, CadastroEnderecoViewModel>().ReverseMap();
            CreateMap<Models.Endereco, RetornoEnderecoViewModel>().ReverseMap();
            CreateMap<Models.Endereco, AtualizaEnderecoViewModel>().ReverseMap();
        }
    }
}
