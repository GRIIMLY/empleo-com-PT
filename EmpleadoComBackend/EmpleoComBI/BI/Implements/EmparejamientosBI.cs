
using AutoMapper;
using EmpleoComRepository.Models;
using Repositories.Repositories;

namespace EmpleoComBI.BI.Implements
{
    internal class EmparejamientosBI : GenericBI<Emparejamiento>, IEmparejamientosBI
    {
        /// <summary>
        /// IEmparejamientosRepository  data access
        /// </summary>
        private readonly IEmparejamientosRepository EmparejamientosRepository;

     

        /// <summary>
        /// mapper 
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="EmparejamientosRepository">objeto de tipo IEmparejamientosRepository</param>
        public EmparejamientosBI(IEmparejamientosRepository EmparejamientosRepository, IMapper mapper)
            : base(EmparejamientosRepository)
        {
            this.EmparejamientosRepository = EmparejamientosRepository;

            this.mapper = mapper;
        }

      

    }
}
