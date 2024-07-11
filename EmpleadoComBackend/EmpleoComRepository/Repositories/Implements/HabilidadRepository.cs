
using Repositories.Repositories;
using EmpleoComRepository.ContextDB;
using EmpleoComRepository.Models;
using System.Linq;

namespace EmpleoComRepository.Repositories.Implements
{
    public class HabilidadRepository : GenericRepository<Habilidad>, IHabilidadRepository
    {
        public readonly EmpleadoComDB _db;

        public HabilidadRepository(EmpleadoComDB _db) : base(_db)
        {
            this._db = _db;
        }


        public List<Habilidad> GetHabilidadPorIdTrabajo(int idTrabajo)
        {
            var result = from habilidadUsuario in _db.HabilidadUsuarios
                         join habilidad in _db.Habilidads on habilidadUsuario.HabilidadId equals habilidad.HabilidadId
                         where habilidadUsuario.TrabajoId == idTrabajo
                         select habilidad;
            return result.ToList();
        }

        public List<Habilidad> GetHabilidadPorIdUsuario(int idUsuario)
        {

            var result = from habilidadUsuario in _db.HabilidadUsuarios
                         join habilidad in _db.Habilidads on habilidadUsuario.HabilidadId equals habilidad.HabilidadId
                         where habilidadUsuario.UsuarioId == idUsuario
                         select habilidad;
            return result.ToList();
        }
    }
      
}
