using AutoMapper;
using ControlePendencias.Application.Interfaces;
using ControlePendencias.Domain.Interfaces;
using System.Collections.Generic;

namespace ControlePendencias.Application
{
    public class ApplicationBase<TViewModel, TEntity> : IApplicationBase<TViewModel>
    {
        private readonly IRepositoryBase<TEntity> _repository;
        private readonly IMapper _mapper;

        public ApplicationBase(IRepositoryBase<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual TViewModel BuscarPorIdentificador(int identificador)
        {
            TEntity entity = _repository.BuscarPorIdentificador(identificador);
            TViewModel viewModel = _mapper.Map<TEntity, TViewModel>(entity);
            return viewModel;
        }

        public virtual IEnumerable<TViewModel> BuscarTodos()
        {
            IEnumerable<TEntity> lista = _repository.BuscarTodos();
            IEnumerable<TViewModel> listaViewModel = _mapper.Map<IEnumerable<TEntity>, IEnumerable<TViewModel>>(lista);
            return listaViewModel;
        }

        public virtual void Deletar(TViewModel objeto)
        {
            TEntity entity = _mapper.Map<TViewModel, TEntity>(objeto);
            _repository.Deletar(entity);
        }

        public virtual void Salvar(TViewModel objeto)
        {
            TEntity entity = _mapper.Map<TViewModel, TEntity>(objeto);
            _repository.Salvar(entity);
        }
    }
}
