using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ControlePendencias.Domain.Interfaces;
using ControlePendencias.Domain;

namespace ControlePendencias.Data.InMemory.Test
{
    [TestClass]
    public class PendenciaRepositoryTest
    {
        private InMemoryDatabaseContext _context;


        [TestInitialize]        
        public void SetUp()
        {
            _context = new InMemoryDatabaseContext();            
        }

        [TestMethod]
        public void Adiciona_Pendencia_Test()
        {
            //Arrange
            IPendenciaRepository repository = new PendenciaRepository(_context);
            var totalPendenciasAntesInserir = repository.BuscarTodos().Count();
            Pendencia Pendencia = new Pendencia
            {
                Id = 2000,
                Titulo = "Pendencia Teste",
                Prioridade = Prioridade.Baixa,
                Complexidade = Complexidade.Baixa,
                DataCadastro = DateTime.Now,
                DataFinal = DateTime.Now.AddDays(1)
            };

            //Act            
            repository.Salvar(Pendencia);

            //Assert
            Assert.AreEqual(repository.BuscarTodos().Count(), totalPendenciasAntesInserir + 1);
        }


        [TestMethod]
        public void Busca_Pendencia_Pelo_Identificador_Test()
        {
            //Arrange
            IPendenciaRepository repository = new PendenciaRepository(_context);

            //Act
            var Pendencia = repository.BuscarPorIdentificador(1000);

            //Assert
            Assert.IsNotNull(Pendencia);
        }

        [TestMethod]
        public void Busca_Pendencias_Em_Atraso_Test()
        {
            //Arrange
            IPendenciaRepository repository = new PendenciaRepository(_context);

            //Act
            var PendenciasSemPendencia = repository.ObterTodasPendenciasEmAtraso();

            //Assert
            Assert.AreEqual(3, PendenciasSemPendencia.Count());
        }

        [TestMethod]
        public void Deleta_Pendencia_Test()
        {
            //Arrange
            IPendenciaRepository repository = new PendenciaRepository(_context);
            var totalPendenciasAntesDeletar = repository.BuscarTodos().Count();

            //Act
            var Pendencia = repository.BuscarPorIdentificador(1000);
            repository.Deletar(Pendencia);

            //Assert
            Assert.AreEqual(totalPendenciasAntesDeletar - 1, repository.BuscarTodos().Count());
        }

    }
}
