using Microsoft.VisualStudio.TestTools.UnitTesting;
using ControlePendencias.Domain;
using ControlePendencias.Domain.Interfaces;
using System;
using System.Linq;

namespace ControlePendencias.Data.InMemory.Test
{
    [TestClass]
    public class ResponsaveilRepositoryTest
    {
        private InMemoryDatabaseContext _context;

        [TestInitialize]
        public void SetUp()
        {
            _context = new InMemoryDatabaseContext();
        }

        [TestMethod]
        public void Adiciona_Responsavel_Test()
        {
            //Arrange
            IResponsavelRepository repository = new ResponsavelRepository(_context);
            var totalResponsaveisAntesInserir = repository.BuscarTodos().Count();
            Responsavel responsavel = new Responsavel
            {
                Nome = "Baraka",
                Funcao = Funcao.Desenvolvedor
            };

            responsavel.VincularPendencia(
                new Pendencia
                {
                    Id = 2000,
                    Titulo = "Pendencia Teste",
                    Prioridade = Prioridade.Baixa,
                    Complexidade = Complexidade.Baixa,
                    DataCadastro = DateTime.Now
                });

            //Act            
            repository.Salvar(responsavel);

            //Assert
            Assert.AreEqual(repository.BuscarTodos().Count(), totalResponsaveisAntesInserir + 1);
        }


        [TestMethod]
        public void Busca_Responsavel_Pelo_Identificador_Test()
        {
            //Arrange
            IResponsavelRepository repository = new ResponsavelRepository(_context);

            //Act
            var responsavel = repository.BuscarPorIdentificador(1);

            //Assert
            Assert.IsNotNull(responsavel);
        }

        [TestMethod]
        public void Busca_Responsaveis_Sem_Pendencias_Test()
        {
            //Arrange
            IResponsavelRepository repository = new ResponsavelRepository(_context);

            //Act
            var responsaveisSemPendencia = repository.BuscarResponsaveisSemPendencia();

            //Assert
            Assert.AreEqual(2, responsaveisSemPendencia.Count());
        }

        [TestMethod]
        public void Deleta_Responsavel_Test()
        {
            //Arrange
            IResponsavelRepository repository = new ResponsavelRepository(_context);
            var totalResponsaveisAntesDeletar = repository.BuscarTodos().Count();

            //Act
            var responsavel = repository.BuscarPorIdentificador(2);
            repository.Deletar(responsavel);

            //Assert
            Assert.AreEqual(totalResponsaveisAntesDeletar - 1, repository.BuscarTodos().Count());
        }
    }
}
