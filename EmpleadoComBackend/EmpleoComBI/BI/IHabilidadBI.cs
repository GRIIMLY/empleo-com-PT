using EmpleoComBI.BI.Implements;
using EmpleoComRepository.Models;


namespace EmpleoComBI.BI
{
    public interface IHabilidadBI : IGenericBI<Habilidad>
    {


        public List<Habilidad> GetHabilidadPorIdUsuario(int idUsuario);
        public List<Habilidad> GetHabilidadPorIdTrabajo(int idTrabajo);
    }
}
