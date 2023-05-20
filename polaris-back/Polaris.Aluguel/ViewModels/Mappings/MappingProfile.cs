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

            CreateMap<Models.Cliente, RetornoClienteViewModel>().ReverseMap();
            CreateMap<Models.Cliente, BuscaClienteViewModel>().ReverseMap();

            CreateMap<Models.Conteiner, RetornoConteinerViewModel>().ReverseMap();   
            CreateMap<Models.Conteiner, BuscaConteinerViewModel>().ReverseMap();
            
            CreateMap<Models.CategoriaConteiner, RetornoCategoriaConteinerViewModel>().ReverseMap();
            CreateMap<Models.TipoConteiner, RetornoTipoConteinerViewModel>().ReverseMap();
        }
    }
}
