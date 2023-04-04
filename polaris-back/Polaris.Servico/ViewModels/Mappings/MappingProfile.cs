using AutoMapper;
using Polaris.Servico.ViewModels;

namespace Polaris.Servico.DTOs.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.Servico, CadastroServicoViewModel>().ReverseMap();
            CreateMap<Models.Servico, RetornoServicoViewModel>().ReverseMap();
            CreateMap<Models.Servico, AtualizaServicoViewModel>().ReverseMap();

            CreateMap<Models.Terceirizado, CadastroTerceirizadoViewModel>().ReverseMap();
            CreateMap<Models.Terceirizado, RetornoTerceirizadoViewModel>().ReverseMap();
            CreateMap<Models.Terceirizado, AtualizaTerceirizadoViewModel>().ReverseMap();
        }
    }
}
