using System.ComponentModel.DataAnnotations;

namespace EmpleadoComFrontend.Models
{
    public class HabilidadUsuarioTrabajoModel
    {

        public int? UsuarioId { get; set; }

        public int HabilidadId { get; set; }

        public int? TrabajoId { get; set; }
    }
}
