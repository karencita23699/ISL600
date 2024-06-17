using System;
using System.Collections.Generic;

namespace Proyecto.Models;

public partial class Campeonato
{
    public int CampeonatoId { get; set; }

    public string Nombre { get; set; } = null!;

    public DateOnly? FechaInicio { get; set; }

    public DateOnly? FechaFin { get; set; }

    public int? UsuarioId { get; set; }

    public virtual ICollection<Fixture> Fixtures { get; set; } = new List<Fixture>();

    public virtual Usuario? Usuario { get; set; }
}
