using System;
using System.Collections.Generic;

namespace Proyecto.Models.BD;

public partial class Resultado
{
    public int ResultadoId { get; set; }

    public int? FixtureId { get; set; }

    public int? GolesLocal { get; set; }

    public int? GolesVisitante { get; set; }

    public virtual Fixture? Fixture { get; set; }
}
