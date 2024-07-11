using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleoComRepository.DTOs
{
    public class DescripcionTrabajoDTO
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
