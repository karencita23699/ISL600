using System;
using System.Collections.Generic;

namespace Proyecto.Models.BD;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Rol { get; set; }

    public virtual ICollection<Campeonato> Campeonatos { get; set; } = new List<Campeonato>();
}
