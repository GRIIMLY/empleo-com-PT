using System;
using System.Collections.Generic;

namespace EmpleoComRepository.Models;

public partial class Emparejamiento
{
    public int EmparejamientoId { get; set; }

    public int DemandanteId { get; set; }

    public int TrabajoId { get; set; }

    public DateTime FechaEmparejamiento { get; set; }

    public virtual Demandante Demandante { get; set; } = null!;

    public virtual DescripcionesTrabajo Trabajo { get; set; } = null!;
}
