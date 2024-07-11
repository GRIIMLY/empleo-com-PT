using System;
using System.Collections.Generic;

namespace EmpleoComRepository.Models;

public partial class Empleadore
{
    public int EmpleadorId { get; set; }

    public string NombreEmpresa { get; set; } = null!;

    public string? Localizacion { get; set; }

    public string? Industria { get; set; }

    public int? NumeroEmpleados { get; set; }

    public int? Vacantes { get; set; }

    public virtual ICollection<DescripcionesTrabajo> DescripcionesTrabajos { get; set; } = new List<DescripcionesTrabajo>();

    public virtual Usuario Empleador { get; set; } = null!;
}
