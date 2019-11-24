
using System.Collections.Generic;

namespace ControlePendencias.Application.Interfaces
{
    public interface IApplicationBase<TViewModel>
    {
        IEnumerable<TViewModel> BuscarTodos();
        TViewModel BuscarPorIdentificador(int identificador);
        void Deletar(TViewModel objeto);
        void Salvar(TViewModel objeto);
    }
}
