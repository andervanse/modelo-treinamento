
using System.Collections.Generic;

namespace ControlePendencias.Domain.Interfaces
{
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> BuscarTodos();
        T BuscarPorIdentificador(int identificador);
        void Deletar(T objeto);
        void Salvar(T objeto);
    }
}
