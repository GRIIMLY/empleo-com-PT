using System.ComponentModel.DataAnnotations;

namespace EmpleadoComFrontend.Models
{
    public class UsuarioModel
    {
        [Required]
        [StringLength(20, ErrorMessage = "El nombre de usuario no puede exceder los 20 caracteres.")]
        public string NombreUsuario { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "La contraseña no puede exceder los 20 caracteres.")]
        public string Contrasenia { get; set; }

        [Required]
        public string TipoUsuario { get; set; }
    }
}
