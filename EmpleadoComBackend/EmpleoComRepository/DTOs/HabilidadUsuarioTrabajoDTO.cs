using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleoComRepository.DTOs
{
    public class HabilidadUsuarioTrabajoDTO
    {

        public int? UsuarioId { get; set; }

        public int HabilidadId { get; set; }

        public int? TrabajoId { get; set; }
    }
}
