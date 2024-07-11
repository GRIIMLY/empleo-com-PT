using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleoComRepository.DTOs
{
    public class DemandanteDTO
    {
        public int DemandanteId { get; set; }

        public string Nombre { get; set; } = null!;

        public int? Edad { get; set; }

        public string? Contacto { get; set; }

        public string? NivelEducacion { get; set; }

        public string? Notas { get; set; }

        public string? ExperienciaLaboral { get; set; }
    }
}
