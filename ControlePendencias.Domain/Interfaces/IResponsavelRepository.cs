
using System.Collections.Generic;

namespace ControlePendencias.Domain.Interfaces
{
    public interface IResponsavelRepository: IRepositoryBase<Responsavel>
    {
        IEnumerable<Responsavel> BuscarResponsaveisSemPendencia();
    }
}
