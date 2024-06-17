using System;
using System.Collections.Generic;

namespace Proyecto.Models.BD;

public partial class Equipo
{
    public int EquipoId { get; set; }

    public string Nombre { get; set; } = null!;

    public int? CapitanId { get; set; }

    public virtual ICollection<Fixture> FixtureEquipoLocals { get; set; } = new List<Fixture>();

    public virtual ICollection<Fixture> FixtureEquipoVisitantes { get; set; } = new List<Fixture>();

    public virtual ICollection<Jugadore> Jugadores { get; set; } = new List<Jugadore>();
}
