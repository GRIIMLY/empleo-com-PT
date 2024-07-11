
using AutoMapper;
using EmpleoComRepository.Models;
using Repositories.Repositories;

namespace EmpleoComBI.BI.Implements
{
    internal class HabilidadUsuarioBI : GenericBI<HabilidadUsuarioTrabajo>, IHabilidadUsuarioBI
    {
        /// <summary>
        /// IHabilidadRepository  data access
        /// </summary>
        private readonly HabilidadUsuarioTrabajoRepository habilidadUsuarioRepository;

     

        /// <summary>
        /// mapper 
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="habilidadUsuarioRepository">objeto de tipo HabilidadUsuarioTrabajoRepository</param>
        public HabilidadUsuarioBI(HabilidadUsuarioTrabajoRepository habilidadUsuarioRepository, IMapper mapper)
            : base(habilidadUsuarioRepository)
        {
            this.habilidadUsuarioRepository = habilidadUsuarioRepository;

            this.mapper = mapper;
        }

        public void DeleteHabilidadPorIdUsuario(int idUsuario)
        {
            this.habilidadUsuarioRepository.DeleteHabilidadPorIdUsuario(idUsuario);
         
        }

        public void DeleteHabilidadPorTrabajoId(int TrabajoId)
        {
            this.habilidadUsuarioRepository.DeleteHabilidadPorTrabajoId(TrabajoId);
        }
    }
}
