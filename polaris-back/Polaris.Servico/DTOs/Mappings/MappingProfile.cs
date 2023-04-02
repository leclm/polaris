using AutoMapper;

namespace Polaris.Servico.DTOs.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.Servico, ServicoDTO>().ReverseMap();
            CreateMap<Models.Terceirizado, TerceirizadoDTO>().ReverseMap();
        }
    }
}
