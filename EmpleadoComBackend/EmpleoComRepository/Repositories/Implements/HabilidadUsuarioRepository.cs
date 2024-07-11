
using Repositories.Repositories;
using EmpleoComRepository.ContextDB;
using EmpleoComRepository.Models;

namespace EmpleoComRepository.Repositories.Implements
{
    public class HabilidadUsuarioRepository : GenericRepository<HabilidadUsuarioTrabajo>, HabilidadUsuarioTrabajoRepository
    {
        private readonly EmpleadoComDB _db;

        public HabilidadUsuarioRepository(EmpleadoComDB _db) : base(_db)
        {
            this._db = _db;
        }


        public void DeleteHabilidadPorIdUsuario(int idUsuario)
        {
            var registrosEncontrados = this._db.HabilidadUsuarios.Where(habilidadUsuario => habilidadUsuario.UsuarioId == idUsuario);
            this._db.RemoveRange(registrosEncontrados);
            this._db.SaveChanges();
        }
        public void DeleteHabilidadPorTrabajoId(int TrabajoId)
        {
            var registrosEncontrados = this._db.HabilidadUsuarios.Where(habilidadUsuario => habilidadUsuario.TrabajoId == TrabajoId);
            this._db.RemoveRange(registrosEncontrados);
            this._db.SaveChanges();
        }
    }
      
}
