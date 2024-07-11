using EmpleoComRepository.Models;
using EmpleoComRepository.Repositories;

namespace Repositories.Repositories
{
    public interface IUsuariosRepository
              : IGenericRepository<Usuario>
    {
        public Usuario GetUsuarioPorNombreUsuario(string usuario);
    }
}
