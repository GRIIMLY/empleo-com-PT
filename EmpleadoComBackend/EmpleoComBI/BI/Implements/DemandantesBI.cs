
using AutoMapper;
using EmpleoComRepository.Models;
using Repositories.Repositories;

namespace EmpleoComBI.BI.Implements
{
    internal class DemandantesBI : GenericBI<Demandante>, IDemandantesBI
    {
        /// <summary>
        /// IDemandantesRepository  data access
        /// </summary>
        private readonly IDemandantesRepository demandantesRepository;

     

        /// <summary>
        /// mapper 
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="demandantesRepository">objeto de tipo IDemandantesRepository</param>
        public DemandantesBI(IDemandantesRepository demandantesRepository, IMapper mapper)
            : base(demandantesRepository)
        {
            this.demandantesRepository = demandantesRepository;

            this.mapper = mapper;
        }

      

    }
}
