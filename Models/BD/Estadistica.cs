using System;
using System.Collections.Generic;

namespace Proyecto.Models.BD;

public partial class Estadistica
{
    public int EstadisticaId { get; set; }

    public int? FixtureId { get; set; }

    public int? JugadorId { get; set; }

    public string? TipoEstadistica { get; set; }

    public string? Descripcion { get; set; }

    public virtual Fixture? Fixture { get; set; }

    public virtual Jugadore? Jugador { get; set; }
}
