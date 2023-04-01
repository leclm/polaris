using AutoMapper;

namespace Polaris.Endereco.DTOs.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.Endereco, EnderecoDTO>().ReverseMap();
        }
    }
}
