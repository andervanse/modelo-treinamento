
using System.Collections.Generic;

namespace ControlePendencias.Domain
{
    public class Responsavel
    {
        public Responsavel()
        {
            _pendencias = new List<Pendencia>();
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public  Funcao Funcao { get; set; }


        private readonly IList<Pendencia> _pendencias;

        public IEnumerable<Pendencia> Pendencias
        {
            get
            {
                return _pendencias;
            }                
        }

        public void VincularPendencia(Pendencia pendencia)
        {
            pendencia.ResponsavelAtual = this;
            _pendencias.Add(pendencia);
        }

        public void DesvincularPendencia(Pendencia pendencia)
        {
            _pendencias.Remove(pendencia);
        }

        public void DesvincularTodasPendencias()
        {
            _pendencias.Clear();
        }
    }

    public enum Funcao { Desenvolvedor, Suporte, Analista }
}


