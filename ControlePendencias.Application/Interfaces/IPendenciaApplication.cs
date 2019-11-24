
using ControlePendencias.Application.ViewModels;
using System.Collections.Generic;

namespace ControlePendencias.Application.Interfaces
{
    public interface IPendenciaApplication: IApplicationBase<PendenciaViewModel>
    {
        IEnumerable<PendenciaViewModel> ObterTodasPendenciasEmAtraso();
    }
}
