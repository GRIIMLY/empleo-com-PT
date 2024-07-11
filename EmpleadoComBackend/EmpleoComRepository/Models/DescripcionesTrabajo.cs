using System;
using System.Collections.Generic;

namespace EmpleoComRepository.Models;

public partial class DescripcionesTrabajo
{
    public int TrabajoId { get; set; }

    public int EmpleadorId { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? Requisitos { get; set; }

    public DateTime FechaPublicacion { get; set; }

    public virtual ICollection<Emparejamiento> Emparejamientos { get; set; } = new List<Emparejamiento>();

    public virtual Empleadore Empleador { get; set; } = null!;
}
