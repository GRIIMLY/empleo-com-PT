
using Repositories.Repositories;
using EmpleoComRepository.Models;
using EmpleoComRepository.ContextDB;

namespace EmpleoComRepository.Repositories.Implements
{
    internal class EmpleadoresRepository : GenericRepository<Empleadore>, IEmpleadoresRepository
    {
        private readonly EmpleadoComDB _db;

        public EmpleadoresRepository(EmpleadoComDB _db) : base(_db)
        {
            this._db = _db;
        }
    }
      
}
