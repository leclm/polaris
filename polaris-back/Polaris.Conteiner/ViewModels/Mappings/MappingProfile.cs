using AutoMapper;
using Polaris.Conteiner.ViewModels;

namespace Polaris.Conteiner.ViewModels.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.TipoConteiner, CadastroTipoConteinerViewModel>().ReverseMap();
            CreateMap<Models.TipoConteiner, AtualizaTipoConteinerViewModel>().ReverseMap();
            CreateMap<Models.TipoConteiner, RetornoTipoConteinerViewModel>().ReverseMap();

            CreateMap<Models.CategoriaConteiner, CadastroCategoriaConteinerViewModel>().ReverseMap();
            CreateMap<Models.CategoriaConteiner, RetornoCategoriaConteinerViewModel>().ReverseMap();
            CreateMap<Models.CategoriaConteiner, AtualizarCategoriaConteinerViewModel>().ReverseMap();
        }
    }
}
