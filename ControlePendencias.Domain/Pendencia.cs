using System;

namespace ControlePendencias.Domain
{
    public class Pendencia
    {
        public Pendencia()
        {
            DataCadastro = DateTime.Now;         
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public Complexidade Complexidade { get; set; }
        public Prioridade Prioridade { get; set; }
        public Status Status { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataFinal { get; set; }
        public int ResponsavelId { get; set; }
        public Responsavel ResponsavelAtual { get; set; }


        public DateTime CalcularDataEstimada()
        {
            if (Complexidade == Complexidade.Baixa)
            {
                return DataCadastro.AddDays(3);
            }
            else if (Complexidade == Complexidade.Media)
            {
                return DataCadastro.AddDays(10);
            }
            else
            {
                return DataCadastro.AddDays(20);
            }
        }

        public bool EstaAtrasada
        {
            get
            {
                return DateTime.Now > DataFinal && Status != Status.Finalizado;
            }
        }

        public bool Valida()
        {
            return !String.IsNullOrEmpty(Titulo) && !String.IsNullOrEmpty(Descricao) && DataFinal >= DataCadastro;
        }
    }

    public enum Status { Aguardando, EmAndamento, Finalizado }

    public enum Prioridade { Alta, Media, Baixa }

    public enum Complexidade  { Alta, Media, Baixa }
}