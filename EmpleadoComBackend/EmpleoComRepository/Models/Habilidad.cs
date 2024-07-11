using System;
using System.Collections.Generic;

namespace EmpleoComRepository.Models;

public partial class Habilidad
{
    public int HabilidadId { get; set; }

    public string NombreHabilidad { get; set; } = null!;

    public virtual ICollection<HabilidadUsuarioTrabajo> HabilidadUsuarios { get; set; } = new List<HabilidadUsuarioTrabajo>();
}
