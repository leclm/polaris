using AutoMapper;

namespace Polaris.CategoriaConteiner.ViewModels.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.CategoriaConteiner, CadastroCategoriaConteinerViewModel>().ReverseMap();
            CreateMap<Models.CategoriaConteiner, RetornoCategoriaConteinerViewModel>().ReverseMap();
            CreateMap<Models.CategoriaConteiner, AtualizarCategoriaConteinerViewModel>().ReverseMap();

        }
    }
}
