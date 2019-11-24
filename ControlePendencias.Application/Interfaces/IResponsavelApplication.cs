
using ControlePendencias.Application.ViewModels;
using System.Collections.Generic;

namespace ControlePendencias.Application.Interfaces
{
    public interface IResponsavelApplication: IApplicationBase<ResponsavelViewModel>
    {
        IEnumerable<ResponsavelViewModel> BuscarResponsaveisSemPendencia();
    }
}
