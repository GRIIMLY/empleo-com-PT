using System.ComponentModel.DataAnnotations;

namespace EmpleadoComFrontend.Models
{
    public class LoginResponseModel
    {
        public int UsuarioId { get; set; }

        public string NombreUsuario { get; set; }

        public string Contrasenia { get; set; }

        public string TipoUsuario { get; set; }
    }
}
