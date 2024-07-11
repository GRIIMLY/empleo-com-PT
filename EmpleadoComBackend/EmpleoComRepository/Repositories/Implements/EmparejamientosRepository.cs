
using Repositories.Repositories;
using EmpleoComRepository.Models;
using EmpleoComRepository.ContextDB;

namespace EmpleoComRepository.Repositories.Implements
{
    internal class EmparejamientosRepository : GenericRepository<Emparejamiento>, IEmparejamientosRepository
    {
        private readonly EmpleadoComDB _db;

        public EmparejamientosRepository(EmpleadoComDB _db) : base(_db)
        {
            this._db = _db;
        }
    }
      
}
