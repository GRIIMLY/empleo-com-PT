using System;
using System.Collections.Generic;

namespace EmpleoComRepository.Models;

public partial class Demandante
{
    public int DemandanteId { get; set; }

    public string Nombre { get; set; } = null!;

    public int? Edad { get; set; }

    public string? Contacto { get; set; }

    public string? NivelEducacion { get; set; }

    public string? Notas { get; set; }

    public string? ExperienciaLaboral { get; set; }


}
