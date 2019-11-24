using AutoMapper;
using ControlePendencias.Application.Interfaces;
using ControlePendencias.Domain;
using ControlePendencias.Domain.Interfaces;
using ControlePendencias.Application.ViewModels;
using System.Collections.Generic;


namespace ControlePendencias.Application
{
    public class ResponsavelApplication : ApplicationBase<ResponsavelViewModel, Responsavel>, IResponsavelApplication
    {
        private readonly IResponsavelRepository _repository;
        private readonly IMapper _mapper;

        public ResponsavelApplication(IResponsavelRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<ResponsavelViewModel> BuscarResponsaveisSemPendencia()
        {
            var entityList = _repository.BuscarResponsaveisSemPendencia();
            var viewModelList = _mapper.Map<IEnumerable<Responsavel>, IEnumerable<ResponsavelViewModel>>(entityList); 
            return viewModelList;
        }
    }
}
