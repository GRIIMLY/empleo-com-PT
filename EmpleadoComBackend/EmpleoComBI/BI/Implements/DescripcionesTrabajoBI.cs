
using AutoMapper;
using EmpleoComRepository.DTOs;
using EmpleoComRepository.Models;
using Repositories.Repositories;

namespace EmpleoComBI.BI.Implements
{
    internal class DescripcionesTrabajoBI : GenericBI<DescripcionesTrabajo>, IDescripcionesTrabajoBI
    {
        /// <summary>
        /// IDescripcionesTrabajoRepository  data access
        /// </summary>
        private readonly IDescripcionesTrabajoRepository descripcionesTrabajoRepository;



        /// <summary>
        /// mapper 
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="descripcionesTrabajoRepository">objeto de tipo IDescripcionesTrabajoRepository</param>
        public DescripcionesTrabajoBI(IDescripcionesTrabajoRepository descripcionesTrabajoRepository, IMapper mapper)
            : base(descripcionesTrabajoRepository)
        {
            this.descripcionesTrabajoRepository = descripcionesTrabajoRepository;

            this.mapper = mapper;
        }

        public List<DescripcionTrabajoDTO> GetDescripcionTrabajoDTOs()
        {
            return this.descripcionesTrabajoRepository.GetDescripcionTrabajoDTOs();
        }
    }
}
