using System;
using System.Collections.Generic;

namespace Proyecto.Models;

public class Fixture
{
    public int FixtureId { get; set; }

    public int? CampeonatoId { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly Hora { get; set; }

    public string Lugar { get; set; } = null!;

    public int? EquipoLocalId { get; set; }

    public int? EquipoVisitanteId { get; set; }

    public int? ArbitroId { get; set; }

    public virtual Arbitro? Arbitro { get; set; }

    public virtual Campeonato? Campeonato { get; set; }

    public virtual Equipo? EquipoLocal { get; set; }

    public virtual Equipo? EquipoVisitante { get; set; }

    public virtual ICollection<Estadistica> Estadisticas { get; set; } = new List<Estadistica>();

    public virtual ICollection<Resultado> Resultados { get; set; } = new List<Resultado>();
}
