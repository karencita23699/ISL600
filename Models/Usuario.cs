using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models;

public class Usuario
{
	[StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
	public string? Nombre { get; set; }

	[Required(ErrorMessage = "El email es obligatorio.")]
	[EmailAddress(ErrorMessage = "El email no tiene un formato válido.")]
	public string Email { get; set; } = null!;

	[Required(ErrorMessage = "La contraseña es obligatoria.")]
	[StringLength(100, MinimumLength = 6, ErrorMessage = "La contraseña debe tener entre 6 y 100 caracteres.")]
	public string Password { get; set; } = null!;

	public string? Rol { get; set; }

    public virtual ICollection<Campeonato> Campeonatos { get; set; } = new List<Campeonato>();
}
