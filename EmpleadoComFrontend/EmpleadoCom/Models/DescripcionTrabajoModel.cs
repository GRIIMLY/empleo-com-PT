using System.ComponentModel.DataAnnotations;

namespace EmpleadoComFrontend.Models
{
    public class DescripcionTrabajoModel
    {
        public int TrabajoId { get; set; }
        public string TituloTrabajo { get; set; }
        public string NombreEmpresa { get; set; }
        public string LocalizacionEmpresa { get; set; }
        public string EnlaceVerMas { get; set; }
        public DateTime? FechaPublicacion { get; set; }

        public List<string> HabilidadesRequeridas { get; set; }
    }
}
