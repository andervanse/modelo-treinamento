
using System.Collections.Generic;
using System.Linq;
using ControlePendencias.Domain;
using ControlePendencias.Domain.Interfaces;

namespace ControlePendencias.Data
{
    public class PendenciaRepository : IPendenciaRepository
    {
        private readonly InMemoryDatabaseContext _contexto;

        public PendenciaRepository(InMemoryDatabaseContext contexto)
        {
            _contexto = contexto;
        }

        public Pendencia BuscarPorIdentificador(int identificador)
        {
            var pendencia = _contexto.Pendencias.FirstOrDefault(p => p.Id == identificador);
            return pendencia;
        }

        public IEnumerable<Pendencia> BuscarTodos()
        {
            return _contexto.Pendencias;
        }

        public void Deletar(Pendencia objeto)
        {
            var objetoDb = _contexto.Pendencias.FirstOrDefault(p => p.Id == objeto.Id);
            _contexto.Pendencias.Remove(objetoDb);
        }

        public IEnumerable<Pendencia> ObterTodasPendenciasEmAtraso()
        {
            return _contexto.Pendencias.Where(p => p.EstaAtrasada);
        }

        public void Salvar(Pendencia objeto)
        {
            if (objeto.Id > 0)
            {
                var pendencia = _contexto.Pendencias.FirstOrDefault(p => p.Id == objeto.Id);

                if (pendencia != null)
                {
                    pendencia.Prioridade = objeto.Prioridade;
                    pendencia.Status = objeto.Status;
                    pendencia.Titulo = objeto.Titulo;
                    pendencia.DataFinal = objeto.DataFinal;
                    pendencia.Descricao = objeto.Descricao;
                    pendencia.ResponsavelAtual = objeto.ResponsavelAtual;
                    pendencia.Complexidade = objeto.Complexidade;
                }
                else
                    _contexto.Pendencias.Add(objeto);
            }
            else
            {
                _contexto.Pendencias.Add(objeto);
            }
            
        }
    }
}
