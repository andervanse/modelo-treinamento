
using System;
using System.Collections.Generic;
using ControlePendencias.Domain;

namespace ControlePendencias.Data
{
    public class InMemoryDatabaseContext
    {
        public IList<Responsavel> Responsaveis { get; }
        public IList<Pendencia> Pendencias { get; }


        public InMemoryDatabaseContext()
        {

            Responsaveis = new List<Responsavel>
            {
                new Responsavel { Id = 1, Nome = "Raiden", Email = "raiden@mk.com", Funcao = Funcao.Analista },
                new Responsavel { Id = 2, Nome = "Kitana", Email = "kitana@mk.com", Funcao = Funcao.Desenvolvedor },
                new Responsavel { Id = 3, Nome = "Jax", Email = "jax@mk.com", Funcao = Funcao.Suporte },
                new Responsavel { Id = 4, Nome = "Rain", Email = "rain@mk.com", Funcao = Funcao.Suporte },
                new Responsavel { Id = 5, Nome = "Cyrax", Email = "cyrax@mk.com", Funcao = Funcao.Analista },
                new Responsavel { Id = 6, Nome = "Jade", Email = "jade@mk.com", Funcao = Funcao.Desenvolvedor },
                new Responsavel { Id = 7, Nome = "Kabal", Email = "kabal@mk.com", Funcao = Funcao.Suporte },
                new Responsavel { Id = 8, Nome = "Nightwolf", Email = "nightwolf@mk.com", Funcao = Funcao.Suporte }
            };


            Pendencias = new List<Pendencia>
            {
                new Pendencia
                {
                    Id = 1000,
                    Titulo = "Configurar sql server",
                    Descricao = "Configurar sql server na máquina do cliente XYZ",
                    Complexidade = Complexidade.Baixa,
                    DataCadastro = DateTime.Now.AddDays(-5),
                    DataFinal = DateTime.Now.AddDays(1),
                    Prioridade = Prioridade.Media,
                    Status = Status.EmAndamento,
                    ResponsavelAtual = Responsaveis[3]
                },
                new Pendencia
                {
                    Id = 1002,
                    Titulo = "Treinamento do módulo de orçamentos",
                    Descricao = "O Treinamento deve ocorrer entre as 10:00 à 12:00",
                    Complexidade = Complexidade.Baixa,
                    DataCadastro = DateTime.Now.AddDays(-3),
                    DataFinal = DateTime.Now.AddDays(2),
                    Prioridade = Prioridade.Media,
                    Status = Status.EmAndamento,
                    ResponsavelAtual = Responsaveis[6]
                },
                new Pendencia
                {
                    Id = 1004,
                    Titulo = "Inconsistência no relatório rpt032",
                    Descricao = "Foi apresentado uma somatória incorreta ao consolidar valores",
                    Complexidade = Complexidade.Baixa,
                    DataCadastro = DateTime.Now.AddDays(-1),
                    DataFinal = DateTime.Now.AddDays(1),
                    Prioridade = Prioridade.Alta,
                    Status = Status.Aguardando,
                    ResponsavelAtual = Responsaveis[3]
                },
                new Pendencia
                {
                    Id = 1006,
                    Titulo = "Erro ao clicar no botão de detalhes",
                    Descricao = "Erro identificado durante os testes da pendência nº 666",
                    Complexidade = Complexidade.Baixa,
                    DataCadastro = DateTime.Now.AddDays(-6),
                    DataFinal = DateTime.Now.AddDays(-1),
                    Prioridade = Prioridade.Alta,
                    Status = Status.Finalizado,
                    ResponsavelAtual = Responsaveis[2]
                },
                new Pendencia
                {
                    Id = 1008,
                    Titulo = "Teste da nova versão",
                    Descricao = "Nova versão encontra-se disponível em Y:\\Versoes\\Testes",
                    Complexidade = Complexidade.Baixa,
                    DataCadastro = DateTime.Now.AddDays(-1),
                    DataFinal = DateTime.Now,
                    Prioridade = Prioridade.Baixa,
                    Status = Status.Finalizado,
                    ResponsavelAtual = Responsaveis[7]
                },
                new Pendencia
                {
                    Id = 1010,
                    Titulo = "Configurar ferramentas de desenvolvimento nas novas máquinas",
                    Descricao = "Instalar Firebird, Sql-Server, Delphi e Visual Studio em todas as máquinas novas",
                    Complexidade = Complexidade.Baixa,
                    DataCadastro = DateTime.Now.AddDays(-10),
                    DataFinal = DateTime.Now,
                    Prioridade = Prioridade.Baixa,
                    Status = Status.Finalizado,
                    ResponsavelAtual = Responsaveis[3]
                },
                new Pendencia
                {
                    Id = 1012,
                    Titulo = "Desenvolver funcionalidade de envio de relatório por e-mail",
                    Descricao = "O sistema deve enviar o relatório após ser gerado automaticamente ao responsável",
                    Complexidade = Complexidade.Alta,
                    DataCadastro = DateTime.Now.AddDays(-30),
                    DataFinal = DateTime.Now.AddDays(-5),
                    Prioridade = Prioridade.Media,
                    Status = Status.EmAndamento,
                    ResponsavelAtual = Responsaveis[1]
                },
                new Pendencia
                {
                    Id = 1014,
                    Titulo = "Criar especificação para o novo módulo de orçamentos ",
                    Descricao = "A especificação deve ter o nome dos responsáveis e as datas estimadas.",
                    Complexidade = Complexidade.Media,
                    DataCadastro = DateTime.Now.AddDays(-12),
                    DataFinal = DateTime.Now.AddDays(-2),
                    Prioridade = Prioridade.Media,
                    Status = Status.Aguardando,
                    ResponsavelAtual = Responsaveis[1]
                },
                new Pendencia
                {
                    Id = 1016,
                    Titulo = "Configuração do novo módulo na empresa XTS",
                    Descricao = "Acessar remotamenta a máquina servidora do cliente para instalação",
                    Complexidade = Complexidade.Media,
                    DataCadastro = DateTime.Now.AddDays(-5),
                    DataFinal = DateTime.Now.AddDays(-1),
                    Prioridade = Prioridade.Media,
                    Status = Status.Aguardando,
                    ResponsavelAtual = Responsaveis[4]
                }
            };

            InicializaPendenciasPorResponsavel();
        }


        private void InicializaPendenciasPorResponsavel()
        {

            foreach (var responsavel in Responsaveis)
            {
                foreach (var pendencia in Pendencias)
                {
                    if (responsavel.Id == pendencia.ResponsavelAtual.Id)
                    {
                        responsavel.VincularPendencia(pendencia);
                    }
                }
            }
        }
    }
}
