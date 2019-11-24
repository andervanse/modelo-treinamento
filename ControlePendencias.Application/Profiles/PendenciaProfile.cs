using AutoMapper;
using ControlePendencias.Application.ViewModels;
using ControlePendencias.Domain;

namespace ControlePendencias.Application.Profiles
{
    public class PendenciaProfile : Profile
    {
        public PendenciaProfile()
        {
            CreateMap<Pendencia, PendenciaViewModel>()
                .ForMember(pvm => pvm.IdResponsavelSelecionado, opt => opt.MapFrom(p => p.ResponsavelId))
                .ReverseMap()
                .ForMember(p => p.ResponsavelId, opt => opt.MapFrom(pvm => pvm.IdResponsavelSelecionado));
        }
    }
}