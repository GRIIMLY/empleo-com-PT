
using AutoMapper;
using EmpleoComRepository.Models;
using Repositories.Repositories;

namespace EmpleoComBI.BI.Implements
{
    internal class HabilidadBI : GenericBI<Habilidad>, IHabilidadBI
    {
        /// <summary>
        /// IHabilidadRepository  data access
        /// </summary>
        private readonly IHabilidadRepository _habilidadRepository;



        /// <summary>
        /// mapper 
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="HabilidadRepository">objeto de tipo IHabilidadRepository</param>
        public HabilidadBI(IHabilidadRepository HabilidadRepository, IMapper mapper)
            : base(HabilidadRepository)
        {
            this._habilidadRepository = HabilidadRepository;

            this.mapper = mapper;
        }

        public List<Habilidad> GetHabilidadPorIdTrabajo(int idTrabajo)
        {
            return this._habilidadRepository.GetHabilidadPorIdTrabajo(idTrabajo);


        }

        public List<Habilidad> GetHabilidadPorIdUsuario(int idUsuario)
        {
            return this._habilidadRepository.GetHabilidadPorIdUsuario(idUsuario);
        }
    }
}
