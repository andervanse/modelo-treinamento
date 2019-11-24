using System;
using System.Collections.Generic;
using AutoMapper;
using ControlePendencias.Application.Interfaces;
using ControlePendencias.Application.ViewModels;
using ControlePendencias.CrossCutting;
using ControlePendencias.Domain;
using ControlePendencias.Domain.Interfaces;

namespace ControlePendencias.Application
{
    public class PendenciaApplication : ApplicationBase<PendenciaViewModel, Pendencia>, IPendenciaApplication
    {
        private readonly IResponsavelApplication _responsavelApp;
        private readonly IPendenciaRepository _repository;
        private readonly IEMailSender _emailSender;
        private readonly IMapper _mapper;

        public PendenciaApplication(
            IResponsavelApplication responsavelApp, 
            IPendenciaRepository repository, 
            IEMailSender emailSender,
            IMapper mapper) : base(repository, mapper)
        {
            _responsavelApp = responsavelApp;
            _repository = repository;
            _emailSender = emailSender;
            _mapper = mapper;
        }

        public IEnumerable<PendenciaViewModel> ObterTodasPendenciasEmAtraso()
        {
            var entityList = _repository.ObterTodasPendenciasEmAtraso();
            var viewModelList = _mapper.Map<IEnumerable<Pendencia>, IEnumerable<PendenciaViewModel>>(entityList);
            return viewModelList;
        }

        public override void Salvar(PendenciaViewModel objeto)
        {
            var responsavelRef = _responsavelApp.BuscarPorIdentificador(objeto.IdResponsavelSelecionado);

            if (responsavelRef == null)
            {
                throw new InvalidOperationException("Responsável pela pendência não localizado");
            }
            else
            {
                objeto.ResponsavelAtual = responsavelRef;
                base.Salvar(objeto);

                _emailSender.SendToAddress = new List<string> { objeto.ResponsavelAtual.Email };
                _emailSender.Subject = "Nova Pendência na sua fila";
                _emailSender.MessageText = string.Format("A Pendência '{0}' foi adicionada a sua fila", objeto.Id);
                _emailSender.Send();
            }
        }

    }
}
