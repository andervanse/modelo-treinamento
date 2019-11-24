using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ControlePendencias.Domain.Interfaces;
using ControlePendencias.Domain;

namespace ControlePendencias.Data.Firebird.Test
{
    [TestClass]
    public class PendenciaRepositoryTest
    {
        private FirebirdContext _context;


        [TestInitialize]        
        public void SetUp()
        {
            _context = new FirebirdContext();
            FirebirdInitializer.Seed(_context);            
        }

        [TestMethod]
        public void Adiciona_Pendencia_Test()
        {
            //Arrange
            IPendenciaRepository repository = new PendenciaRepository(_context);
            var totalPendenciasAntesInserir = repository.BuscarTodos().Count();

            Pendencia Pendencia = new Pendencia
            {
                Titulo = "Pendencia Teste",
                Descricao = "Descrição da Pendência",
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
            var Pendencia = repository.BuscarPorIdentificador(1);

            //Assert
            Assert.IsNotNull(Pendencia);
        }

        [TestMethod]
        public void Deleta_Pendencia_Test()
        {
            //Arrange
            IPendenciaRepository repository = new PendenciaRepository(_context);
            var totalPendenciasAntesDeletar = repository.BuscarTodos().Count();

            //Act
            var Pendencia = repository.BuscarPorIdentificador(1);
            repository.Deletar(Pendencia);

            //Assert
            Assert.AreEqual(totalPendenciasAntesDeletar - 1, repository.BuscarTodos().Count());
        }

    }
}
