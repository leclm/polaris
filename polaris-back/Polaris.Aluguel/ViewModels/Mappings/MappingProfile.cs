using AutoMapper;

namespace Polaris.Aluguel.ViewModels.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.Aluguel, CadastroAluguelViewModel>().ReverseMap();
            CreateMap<Models.Aluguel, AtualizaAluguelViewModel>().ReverseMap();
            CreateMap<Models.Aluguel, RetornoAluguelViewModel>().ReverseMap();
            CreateMap<Models.Aluguel, BuscaAluguelViewModel>().ReverseMap();

            CreateMap<Models.Endereco, CadastroEnderecoViewModel>().ReverseMap();
            CreateMap<Models.Endereco, RetornoEnderecoViewModel>().ReverseMap();
            CreateMap<Models.Endereco, AtualizaEnderecoViewModel>().ReverseMap();
        }
    }
}
