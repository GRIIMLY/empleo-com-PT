using EmpleoComBI.BI.Implements;
using EmpleoComRepository.Models;


namespace EmpleoComBI.BI
{
    public interface IHabilidadUsuarioBI : IGenericBI<HabilidadUsuarioTrabajo>
    {

        public void DeleteHabilidadPorIdUsuario(int idUsuario);
        public void DeleteHabilidadPorTrabajoId(int TrabajoId);

    }
}
