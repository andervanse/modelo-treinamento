
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using ControlePendencias.Domain;
using ControlePendencias.Domain.Interfaces;

namespace ControlePendencias.Data.Firebird
{
    public class PendenciaRepository : IPendenciaRepository
    {
        private readonly FirebirdContext _contexto;

        public PendenciaRepository(FirebirdContext contexto)
        {
            _contexto = contexto;
        }

        public Pendencia BuscarPorIdentificador(int identificador)
        {
            var pendencia = _contexto.Pendencias
                                     .Include(p => p.ResponsavelAtual)
                                     .FirstOrDefault(p => p.Id == identificador);
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
            _contexto.SaveChanges();
        }

        public IEnumerable<Pendencia> ObterTodasPendenciasEmAtraso()
        {
            return _contexto.Pendencias.ToList().Where(p => p.EstaAtrasada);
        }

        public void Salvar(Pendencia objeto)
        {
            if (objeto.Id > 0)
            {
                var pendencia = _contexto.Pendencias.FirstOrDefault(p => p.Id == objeto.Id);

                if (pendencia != null)
                {
                    pendencia.ResponsavelId = objeto.ResponsavelId;
                    pendencia.Prioridade    = objeto.Prioridade;
                    pendencia.Status        = objeto.Status;
                    pendencia.Titulo        = objeto.Titulo;
                    pendencia.DataFinal     = objeto.DataFinal;
                    pendencia.Descricao     = objeto.Descricao;
                    pendencia.Complexidade  = objeto.Complexidade;
                }
                else
                    _contexto.Pendencias.Add(objeto);
            }
            else
            {
                _contexto.Pendencias.Add(objeto);
            }

            _contexto.SaveChanges();            
        }
    }
}
