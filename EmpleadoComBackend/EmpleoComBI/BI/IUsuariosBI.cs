using EmpleoComRepository.Models;


namespace EmpleoComBI.BI
{
    public interface IUsuariosBI : IGenericBI<Usuario>
    {

        public Usuario GetUsuarioPorNombreUsuario(string usuario);


    }
}
