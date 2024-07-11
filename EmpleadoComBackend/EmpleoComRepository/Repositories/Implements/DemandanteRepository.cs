
using Repositories.Repositories;
using EmpleoComRepository.ContextDB;
using EmpleoComRepository.Models;

namespace EmpleoComRepository.Repositories.Implements
{
    internal class DemandanteRepository : GenericRepository<Demandante>, IDemandantesRepository
    {
        private readonly EmpleadoComDB _db;

        public DemandanteRepository(EmpleadoComDB _db) : base(_db)
        {
            this._db = _db;
        }
    }
      
}
