using ControlePendencias.Domain;
using ControlePendencias.Domain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace ControlePendencias.Data.Firebird.Test
{


    [TestClass]
    public class ResponsaveilRepositoryTest
    {
        private FirebirdContext _context;

        [TestInitialize]
        public void SetUp()
        {
            _context = new FirebirdContext();
            FirebirdInitializer.Seed(_context);
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
                Email = "baraka@mk.com",
                Funcao = Funcao.Desenvolvedor
            };

            responsavel.VincularPendencia(
                new Pendencia
                {
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

    }

}
