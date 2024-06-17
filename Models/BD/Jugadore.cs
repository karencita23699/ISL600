using System;
using System.Collections.Generic;

namespace Proyecto.Models.BD;

public partial class Jugadore
{
    public int JugadorId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Posicion { get; set; }

    public int? EquipoId { get; set; }

    public virtual Equipo? Equipo { get; set; }

    public virtual ICollection<Estadistica> Estadisticas { get; set; } = new List<Estadistica>();
}
