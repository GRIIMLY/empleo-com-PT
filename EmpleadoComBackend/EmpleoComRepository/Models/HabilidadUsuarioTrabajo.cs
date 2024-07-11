using System;
using System.Collections.Generic;

namespace EmpleoComRepository.Models;

public partial class HabilidadUsuarioTrabajo
{
    public int HabilidadUsuarioId { get; set; }

    public int? UsuarioId { get; set; }

    public int HabilidadId { get; set; }

    public int? TrabajoId { get; set; }
}
