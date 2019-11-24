using ControlePendencias.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ControlePendencias.Data.Firebird.Test
{
    public static class FirebirdInitializer 
    {
        private static bool runOnce = false;
        public static IList<Responsavel> Responsaveis { get; set; }
        public static IList<Pendencia> Pendencias { get; set; }

        public static void Seed(FirebirdContext context)
        {
            Debug.WriteLine("Starting seed method...");

            if (!runOnce)
            {
                Debug.WriteLine("Running database commands...");
                context.Database.ExecuteSqlCommand("DELETE FROM PENDENCIA;");
                context.Database.ExecuteSqlCommand("DELETE FROM RESPONSAVEL;");
                context.Database.ExecuteSqlCommand("ALTER SEQUENCE GEN_PENDENCIA_ID RESTART WITH 0;");
                context.Database.ExecuteSqlCommand("ALTER SEQUENCE GEN_RESPONSAVEL_ID RESTART WITH 0;");

                Debug.WriteLine("seeding data...");
                Responsaveis = new List<Responsavel>
                {
                    new Responsavel { Nome = "Raiden", Email = "raiden@mk.com", Funcao = Funcao.Analista },
                    new Responsavel { Nome = "Kitana", Email = "kitana@mk.com", Funcao = Funcao.Desenvolvedor },
                    new Responsavel { Nome = "Jax", Email = "jax@mk.com", Funcao = Funcao.Suporte },
                    new Responsavel { Nome = "Rain", Email = "rain@mk.com", Funcao = Funcao.Suporte },
                    new Responsavel { Nome = "Cyrax", Email = "cyrax@mk.com", Funcao = Funcao.Analista },
                    new Responsavel { Nome = "Jade", Email = "jade@mk.com", Funcao = Funcao.Desenvolvedor },
                    new Responsavel { Nome = "Kabal", Email = "kabal@mk.com", Funcao = Funcao.Suporte },
                    new Responsavel { Nome = "Nightwolf", Email = "nightwolf@mk.com", Funcao = Funcao.Suporte }
                };

                Pendencias = new List<Pendencia>
                {
                    new Pendencia
                    {
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

                context.Responsaveis.AddRange(Responsaveis);
                context.Pendencias.AddRange(Pendencias);
                context.SaveChanges();
                Debug.WriteLine("finishing seed data...");

                runOnce = true;
            }

        }

        private static void InicializaPendenciasPorResponsavel()
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
