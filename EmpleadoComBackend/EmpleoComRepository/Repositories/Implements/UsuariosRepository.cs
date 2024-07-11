
using Repositories.Repositories;
using EmpleoComRepository.Models;
using EmpleoComRepository.ContextDB;

namespace EmpleoComRepository.Repositories.Implements
{
    internal class UsuariosRepository : GenericRepository<Usuario>, IUsuariosRepository
    {
        private readonly EmpleadoComDB _db;

        public UsuariosRepository(EmpleadoComDB _db) : base(_db)
        {
            this._db = _db;
        }

        public Usuario GetUsuarioPorNombreUsuario(string usuario)
        {
            return this._db.Usuarios.Where(usu => usu.NombreUsuario.Equals(usuario)).FirstOrDefault();
        }
    }

}
