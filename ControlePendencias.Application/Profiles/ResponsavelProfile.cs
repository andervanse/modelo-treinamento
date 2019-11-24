using AutoMapper;
using ControlePendencias.Domain;
using ControlePendencias.Application.ViewModels;

namespace ControlePendencias.Application.Profiles
{
    public class ResponsavelProfile : Profile
    {
        public ResponsavelProfile()
        {
            CreateMap<Responsavel, ResponsavelViewModel>().ReverseMap();
        }
    }
}