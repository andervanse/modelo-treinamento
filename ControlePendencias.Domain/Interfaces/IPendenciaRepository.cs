
using System.Collections.Generic;

namespace ControlePendencias.Domain.Interfaces
{
    public interface IPendenciaRepository: IRepositoryBase<Pendencia>
    {
        IEnumerable<Pendencia> ObterTodasPendenciasEmAtraso();
    }
}
