using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleoComRepository.DTOs
{
    public class UsuarioDTO
    {
        public string NombreUsuario { get; set; }

        public string Contrasenia { get; set; }

        public string TipoUsuario { get; set; }
    }
}
