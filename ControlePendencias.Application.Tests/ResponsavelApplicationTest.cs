using ControlePendencias.Application;
using ControlePendencias.Application.Interfaces;
using ControlePendencias.Application.Tests;
using ControlePendencias.Data;
using ControlePendencias.Domain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ControleResponsavels.Application.Tests
{
    [TestClass]
    public class ResponsavelApplicationTest : ApplicationBaseTest
    {
        private IResponsavelRepository _repository;

        [TestInitialize]
        public override void SetUp()
        {
            base.SetUp();
            _repository = new ResponsavelRepository(Context);
        }


        [TestMethod]
        public void Busca_Responsavel_Pelo_Identificador_Test()
        {
            //Arrange
            IResponsavelApplication responsavelApp = new ResponsavelApplication(_repository, Mapping);

            //Act
            var responsavel = responsavelApp.BuscarPorIdentificador(2);

            //Assert
            Assert.IsNotNull(responsavel);
        }

        [TestMethod]
        public void Busca_Responsavels_Sem_Pendencias_Test()
        {
            //Arrange
            IResponsavelApplication responsavelApp = new ResponsavelApplication(_repository, Mapping);

            //Act
            var responsaveisSemPendencia = responsavelApp.BuscarResponsaveisSemPendencia();

            //Assert
            Assert.AreEqual(2, responsaveisSemPendencia.Count());
        }

        [TestMethod]
        public void Deleta_Responsavel_Test()
        {
            //Arrange
            IResponsavelApplication responsavelApp = new ResponsavelApplication(_repository, Mapping);
            var totalResponsavelsAntesDeletar = responsavelApp.BuscarTodos().Count();

            //Act
            var responsavel = responsavelApp.BuscarPorIdentificador(1);
            responsavelApp.Deletar(responsavel);

            //Assert
            Assert.AreEqual(totalResponsavelsAntesDeletar - 1, responsavelApp.BuscarTodos().Count());
        }
    }
}
