
using AutoMapper;
using EmpleoComRepository.Models;
using Repositories.Repositories;

namespace EmpleoComBI.BI.Implements
{
    internal class EmpleadoresBI : GenericBI<Empleadore>, IEmpleadoresBI
    {
        /// <summary>
        /// IEmpleadoresRepository  data access
        /// </summary>
        private readonly IEmpleadoresRepository EmpleadoressRepository;

     

        /// <summary>
        /// mapper 
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="EmpleadoressRepository">objeto de tipo IEmpleadoressRepository</param>
        public EmpleadoresBI(IEmpleadoresRepository EmpleadoressRepository, IMapper mapper)
            : base(EmpleadoressRepository)
        {
            this.EmpleadoressRepository = EmpleadoressRepository;

            this.mapper = mapper;
        }

      

    }
}
