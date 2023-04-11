using AutoMapper;

namespace Polaris.TipoConteiner.ViewModels.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.TipoConteiner, CadastroTipoConteinerViewModel>().ReverseMap();
            CreateMap<Models.TipoConteiner, AtualizaTipoConteinerViewModel>().ReverseMap();
            CreateMap<Models.TipoConteiner, RetornoTipoConteinerViewModel>().ReverseMap();
        }
    }
}
