using System;
using System.Collections.Generic;

namespace EmpleoComRepository.Models;

public partial class Usuario
{
    public int? UsuarioId { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Contrasenia { get; set; } = null!;

    public string TipoUsuario { get; set; } = null!;
}
