
using AutoMapper;
using EmpleoComRepository.Models;
using Repositories.Repositories;

namespace EmpleoComBI.BI.Implements
{
    internal class UsuariosBI : GenericBI<Usuario>, IUsuariosBI
    {
        /// <summary>
        /// IUsuariosRepository  data access
        /// </summary>
        private readonly IUsuariosRepository UsuariossRepository;

     

        /// <summary>
        /// mapper 
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="UsuariossRepository">objeto de tipo IUsuariossRepository</param>
        public UsuariosBI(IUsuariosRepository UsuariossRepository, IMapper mapper)
            : base(UsuariossRepository)
        {
            this.UsuariossRepository = UsuariossRepository;

            this.mapper = mapper;
        }

        public Usuario GetUsuarioPorNombreUsuario(string usuario)
        {
            return this.UsuariossRepository.GetUsuarioPorNombreUsuario(usuario);
        }
    }
}
