using AutoMapper;

namespace Polaris.Servico.ViewModels.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.Servico, CadastroServicoViewModel>().ReverseMap();
            CreateMap<Models.Servico, RetornoServicoViewModel>().ReverseMap();
            CreateMap<Models.Servico, AtualizaServicoViewModel>().ReverseMap();
            CreateMap<Models.Servico, BuscaServicoViewModel>().ReverseMap();

            CreateMap<Models.Terceirizado, CadastroTerceirizadoViewModel>().ReverseMap();
            CreateMap<Models.Terceirizado, RetornoTerceirizadoViewModel>().ReverseMap();
            CreateMap<Models.Terceirizado, AtualizaTerceirizadoViewModel>().ReverseMap();

            CreateMap<Models.Endereco, CadastroEnderecoViewModel>().ReverseMap();
            CreateMap<Models.Endereco, RetornoEnderecoViewModel>().ReverseMap();
            CreateMap<Models.Endereco, AtualizaEnderecoViewModel>().ReverseMap();
        }
    }
}
