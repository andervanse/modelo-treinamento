using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControlePendencias.Domain.Test
{
    [TestClass]
    public class PendenciaTest
    {

        [TestInitialize]
        public void SetUp()
        {

        }

        [TestMethod]
        public void Calculo_Data_Estimada_Complexidade_Baixa_Test()
        {
            var dataCadastro = new DateTime(2019, 9, 21);
            var pendencia = new Pendencia
            {
                Titulo = "Pendencia Teste",
                Descricao = "Descrição Teste",
                DataCadastro = dataCadastro,
                DataFinal = new DateTime(2019, 10, 15),
                Complexidade = Complexidade.Baixa,
                Status = Status.EmAndamento
            };

            var dataEstimada = pendencia.CalcularDataEstimada();
            Assert.AreEqual(dataCadastro.AddDays(3), dataEstimada);
        }

        [TestMethod]
        public void Calculo_Data_Estimada_Complexidade_Media_Test()
        {
            var dataCadastro = new DateTime(2019, 9, 21);
            var pendencia = new Pendencia
            {
                Titulo = "Pendencia Teste",
                Descricao = "Descrição Teste",
                DataCadastro = dataCadastro,
                DataFinal = new DateTime(2019, 10, 15),
                Complexidade = Complexidade.Media,
                Status = Status.EmAndamento
            };

            var dataEstimada = pendencia.CalcularDataEstimada();
            Assert.AreEqual(dataCadastro.AddDays(10), dataEstimada);
        }

        [TestMethod]
        public void Calculo_Data_Estimada_Complexidade_Alta_Test()
        {
            var dataCadastro = new DateTime(2019, 9, 21);
            var pendencia = new Pendencia
            {
                Titulo = "Pendencia Teste",
                Descricao = "Descrição Teste",
                DataCadastro = dataCadastro,
                DataFinal = new DateTime(2019, 10, 15),
                Complexidade = Complexidade.Alta,
                Status = Status.EmAndamento
            };

            var dataEstimada = pendencia.CalcularDataEstimada();
            Assert.AreEqual(dataCadastro.AddDays(20), dataEstimada);
        }


        [TestMethod]
        public void Validacao_Pendencia_Test()
        {
            var dataCadastro = new DateTime(2019, 9, 21);
            Pendencia pendencia = new Pendencia
            {
                Titulo = "Pendencia Teste",
                Descricao = "Descrição Teste",
                DataCadastro = dataCadastro,
                DataFinal = new DateTime(2019, 10, 15),
                Complexidade = Complexidade.Alta,
                Status = Status.EmAndamento
            };

            var pendenciaValida = pendencia.Valida();
            Assert.IsTrue(pendenciaValida);
        }

        [TestMethod]
        public void Validacao_Pendencia_Invalida_Test()
        {
            Pendencia pendencia = new Pendencia
            {
                Titulo = "Pendencia Teste",
                Descricao = "Descrição Teste",
                DataCadastro = new DateTime(2019, 09, 21),
                DataFinal = new DateTime(2019, 01, 05)
            };

            var pendenciaValida = pendencia.Valida();
            Assert.IsFalse(pendenciaValida);
        }

        [TestMethod]
        public void Pendencia_Atrasada_Test()
        {
            //Arrange
            Pendencia pendencia = new Pendencia
            {
                Titulo = "Pendencia Teste",
                Descricao = "Descrição Teste",
                DataCadastro = new DateTime(2019, 09, 21),
                DataFinal = new DateTime(2019, 10, 05),
                Status = Status.Aguardando
            };

            //Act
            var pendenciaAtrasada = pendencia.EstaAtrasada;

            //Assert
            Assert.IsTrue(pendenciaAtrasada);
        }

        [TestMethod]
        public void Pendencia_Nao_Atrasada_Test()
        {
            //Arrange
            Pendencia pendencia = new Pendencia
            {
                Titulo = "Pendencia Teste",
                Descricao = "Descrição Teste",
                DataCadastro = new DateTime(2019, 09, 21),
                DataFinal = new DateTime(2019, 10, 05),
                Status = Status.Finalizado
            };

            //Act
            var pendenciaAtrasada = pendencia.EstaAtrasada;

            //Assert
            Assert.IsFalse(pendenciaAtrasada);
        }
    }
}
