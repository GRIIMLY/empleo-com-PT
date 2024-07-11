
using Repositories.Repositories;
using EmpleoComRepository.Models;
using EmpleoComRepository.ContextDB;
using EmpleoComRepository.DTOs;

namespace EmpleoComRepository.Repositories.Implements
{
    internal class DescripcionesTrabajoRepository : GenericRepository<DescripcionesTrabajo>, IDescripcionesTrabajoRepository
    {
        private readonly EmpleadoComDB _db;

        public DescripcionesTrabajoRepository(EmpleadoComDB _db) : base(_db)
        {
            this._db = _db;
        }

        public List<DescripcionTrabajoDTO> GetDescripcionTrabajoDTOs()
        {
            var descripcionesDeTrabajo = from descripcionesTrabajo in _db.DescripcionesTrabajos
                                         join empleadores in _db.Empleadores on descripcionesTrabajo.EmpleadorId equals empleadores.EmpleadorId
                                         select new DescripcionTrabajoDTO
                                         {
                                             TrabajoId = descripcionesTrabajo.TrabajoId,
                                             NombreEmpresa = empleadores.NombreEmpresa,
                                             LocalizacionEmpresa = empleadores.Localizacion,
                                             TituloTrabajo = descripcionesTrabajo.Titulo,
                                             FechaPublicacion = descripcionesTrabajo.FechaPublicacion, 
                                             HabilidadesRequeridas = (from habilidad in _db.Habilidads
                                                                      join habilidadUsuario in _db.HabilidadUsuarios on habilidad.HabilidadId equals habilidadUsuario.HabilidadId
                                                                      where habilidadUsuario.TrabajoId == descripcionesTrabajo.TrabajoId
                                                                      select habilidad.NombreHabilidad).ToList()
                                         };

            return descripcionesDeTrabajo.ToList();
        }
    }

}
