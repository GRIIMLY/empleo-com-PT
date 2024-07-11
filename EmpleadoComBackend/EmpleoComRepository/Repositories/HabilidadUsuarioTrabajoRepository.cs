using EmpleoComRepository.Models;
using EmpleoComRepository.Repositories;

namespace Repositories.Repositories
{
    public interface HabilidadUsuarioTrabajoRepository
        : IGenericRepository<HabilidadUsuarioTrabajo>
    {
        public void DeleteHabilidadPorIdUsuario(int idUsuario);
        public void DeleteHabilidadPorTrabajoId(int TrabajoId);

    }
}
