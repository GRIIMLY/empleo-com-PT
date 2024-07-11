using EmpleoComRepository.DTOs;
using EmpleoComRepository.Models;
using EmpleoComRepository.Repositories;

namespace Repositories.Repositories
{
    public interface IDescripcionesTrabajoRepository
        : IGenericRepository<DescripcionesTrabajo>
    {
        public List<DescripcionTrabajoDTO> GetDescripcionTrabajoDTOs();

    }
}
