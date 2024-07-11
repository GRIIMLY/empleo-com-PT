using System.ComponentModel.DataAnnotations;

namespace EmpleadoComFrontend.Models
{
    public class DemandanteModel
    {
        public int? DemandanteId { get; set; }

        [Required]
        public string Nombre { get; set; } = null!;
        
        [Required]
        public int? Edad { get; set; }

        [Required]
        public string? Contacto { get; set; }
       
        [Required]
        public string? NivelEducacion { get; set; }

        [Required]

        public string? Notas { get; set; }

        [Required]

        public string? ExperienciaLaboral { get; set; }
    }
}
