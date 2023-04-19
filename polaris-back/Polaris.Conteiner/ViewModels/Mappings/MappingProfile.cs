using AutoMapper;

namespace Polaris.Conteiner.ViewModels.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.TipoConteiner, CadastroTipoConteinerViewModel>().ReverseMap();
            CreateMap<Models.TipoConteiner, AtualizaTipoConteinerViewModel>().ReverseMap();
            CreateMap<Models.TipoConteiner, RetornoTipoConteinerViewModel>().ReverseMap();
            CreateMap<Models.TipoConteiner, BuscaTipoViewModel>().ReverseMap();

            CreateMap<Models.CategoriaConteiner, CadastroCategoriaConteinerViewModel>().ReverseMap();
            CreateMap<Models.CategoriaConteiner, AtualizaCategoriaConteinerViewModel>().ReverseMap();
            CreateMap<Models.CategoriaConteiner, RetornoCategoriaConteinerViewModel>().ReverseMap();
            CreateMap<Models.CategoriaConteiner, BuscaCategoriaViewModel>().ReverseMap();

            CreateMap<Models.Conteiner, CadastroConteinerViewModel>().ReverseMap();
            CreateMap<Models.Conteiner, AtualizaConteinerViewModel>().ReverseMap();
            CreateMap<Models.Conteiner, RetornoConteinerViewModel>().ReverseMap();
        }
    }
}
