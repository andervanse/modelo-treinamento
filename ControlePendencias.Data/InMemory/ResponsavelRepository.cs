﻿

using System.Collections.Generic;
using System.Linq;
using ControlePendencias.Domain;
using ControlePendencias.Domain.Interfaces;

namespace ControlePendencias.Data
{
    public class ResponsavelRepository : IResponsavelRepository
    {

        private readonly InMemoryDatabaseContext _contexto;

        public ResponsavelRepository(InMemoryDatabaseContext contexto)
        {
            _contexto = contexto;
        }

        public Responsavel BuscarPorIdentificador(int identificador)
        {
            return _contexto.Responsaveis.FirstOrDefault(r => r.Id == identificador);
        }

        public IEnumerable<Responsavel> BuscarResponsaveisSemPendencia()
        {
            return _contexto.Responsaveis.Where(r => r.Pendencias.Count() == 0);
        }

        public IEnumerable<Responsavel> BuscarTodos()
        {
            return _contexto.Responsaveis;
        }

        public void Deletar(Responsavel objeto)
        {
            var objetoDb = _contexto.Responsaveis.FirstOrDefault(p => p.Id == objeto.Id);
            _contexto.Responsaveis.Remove(objetoDb);
        }

        public void Salvar(Responsavel objeto)
        {

            if (objeto.Id == 0)
            {
                objeto.Id = _contexto.Responsaveis.Count + 1;
                _contexto.Responsaveis.Add(objeto);
            }
            else
            {
                var responsavelSalvo = BuscarPorIdentificador(objeto.Id);
                responsavelSalvo.Nome = objeto.Nome;
                responsavelSalvo.Funcao = objeto.Funcao;
                responsavelSalvo.DesvincularTodasPendencias();

                foreach (var p in objeto.Pendencias)
                {
                    responsavelSalvo.VincularPendencia(p);
                }
            }
        }
    }
}
