using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ControlePendencias.Application.Interfaces;
using ControlePendencias.Data;
using ControlePendencias.Domain;
using ControlePendencias.Domain.Interfaces;
using ControlePendencias.Application.ViewModels;
using Moq;
using ControlePendencias.CrossCutting;

namespace ControlePendencias.Application.Tests
{
    [TestClass]
    public class PendenciaApplicationTest: ApplicationBaseTest
    {
        private IPendenciaRepository _repository;
        private IResponsavelApplication _responsavelApp;
        private IEMailSender _emailSender;

        [TestInitialize]
        public override void SetUp()
        {
            base.SetUp();
            _repository = new PendenciaRepository(Context);

            _responsavelApp = new Mock<IResponsavelApplication>().Object;

            var emailSenderMock = new Mock<IEMailSender>();
            emailSenderMock
                .Setup(es => es.Send())
                .Returns(true);

            _emailSender = emailSenderMock.Object;
        }


        
        
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Não deve existir pendência sem responsável")]
        public void Adiciona_Pendencia_Sem_Responsavel_Test()
        {

            //Arrange
            IPendenciaApplication pendenciaApp = new PendenciaApplication(_responsavelApp, _repository, _emailSender, Mapping);

            var totalPendenciasAntesInserir = pendenciaApp.BuscarTodos().Count();
            PendenciaViewModel pendencia = new PendenciaViewModel
            {
                Id = 2000,
                Titulo = "Pendencia Teste",
                Prioridade = Prioridade.Baixa,
                Complexidade = Complexidade.Baixa,
                DataCadastro = DateTime.Now,
                DataFinal = DateTime.Now.AddDays(1)
            };

            //Act            
            pendenciaApp.Salvar(pendencia);

            //Assert
            Assert.AreEqual(pendenciaApp.BuscarTodos().Count(), totalPendenciasAntesInserir + 1);
        }

        [TestMethod]
        public void Adiciona_Pendencia_Com_Responsavel_Test()
        {
            //Arrange
            var responsavelAppMock = new Mock<IResponsavelApplication>();

            responsavelAppMock
                .Setup(ra => ra.BuscarPorIdentificador(999))
                .Returns(new ResponsavelViewModel { Id = 999, Nome = "Goro", Email = "goro@mk.com", Funcao = Funcao.Suporte });

            IPendenciaApplication pendenciaApp = new PendenciaApplication(responsavelAppMock.Object, _repository, _emailSender, Mapping);

            var totalPendenciasAntesInserir = pendenciaApp.BuscarTodos().Count();
            PendenciaViewModel pendencia = new PendenciaViewModel
            {
                Id = 2000,
                Titulo = "Pendencia Teste",
                Prioridade = Prioridade.Baixa,
                Complexidade = Complexidade.Baixa,
                DataCadastro = DateTime.Now,
                DataFinal = DateTime.Now.AddDays(1),
                IdResponsavelSelecionado = 999
            };

            //Act            
            pendenciaApp.Salvar(pendencia);

            //Assert
            Assert.AreEqual(pendenciaApp.BuscarTodos().Count(), totalPendenciasAntesInserir + 1);
        }


        [TestMethod]
        public void Busca_Pendencia_Pelo_Identificador_Test()
        {
            //Arrange
            IPendenciaApplication pendenciaApp = new PendenciaApplication(_responsavelApp, _repository, _emailSender, Mapping);

            //Act
            var Pendencia = pendenciaApp.BuscarPorIdentificador(1000);

            //Assert
            Assert.IsNotNull(Pendencia);
        }

        [TestMethod]
        public void Busca_Pendencias_Em_Atraso_Test()
        {
            //Arrange
            IPendenciaApplication pendenciaApp = new PendenciaApplication(_responsavelApp, _repository, _emailSender, Mapping);

            //Act
            var PendenciasSemPendencia = pendenciaApp.ObterTodasPendenciasEmAtraso();

            //Assert
            Assert.AreEqual(3, PendenciasSemPendencia.Count());
        }

        [TestMethod]
        public void Deleta_Pendencia_Test()
        {
            //Arrange
            IPendenciaApplication pendenciaApp = new PendenciaApplication(_responsavelApp, _repository, _emailSender, Mapping);
            var totalPendenciasAntesDeletar = pendenciaApp.BuscarTodos().Count();

            //Act
            var Pendencia = pendenciaApp.BuscarPorIdentificador(1000);
            pendenciaApp.Deletar(Pendencia);

            //Assert
            Assert.AreEqual(totalPendenciasAntesDeletar - 1, pendenciaApp.BuscarTodos().Count());
        }
    }
}
