using System;
using System.Collections.Generic;

namespace Proyecto.Models;

public  class Arbitro
{
    public int ArbitroId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Fixture> Fixtures { get; set; } = new List<Fixture>();
}
