using EmpleoComRepository.Models;
using EmpleoComRepository.Repositories;

namespace Repositories.Repositories
{
    public interface IHabilidadRepository
        : IGenericRepository<Habilidad>
    {
        public List<Habilidad> GetHabilidadPorIdUsuario(int idUsuario);
        public List<Habilidad> GetHabilidadPorIdTrabajo(int idTrabajo);

    }
}
