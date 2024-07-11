using EmpleoComRepository.DTOs;
using EmpleoComRepository.Models;


namespace EmpleoComBI.BI
{
    public interface IDescripcionesTrabajoBI : IGenericBI<DescripcionesTrabajo>
    {


        public List<DescripcionTrabajoDTO> GetDescripcionTrabajoDTOs();

    }
}
