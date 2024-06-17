using Microsoft.AspNetCore.Mvc;
using Proyecto.Models;
using Proyecto.Models.BD;

namespace Proyecto.Controllers
{
	public class LoginController : Controller
	{
		DbFutbolContext _context;

		public LoginController(DbFutbolContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			return View(new Models.Usuario());
		}
		[HttpPost]
		public IActionResult IniciarSesion(Models.Usuario usuario)
		{
			if (ModelState.IsValid)
			{
				var us = _context.Usuarios.SingleOrDefault(u => u.Email == usuario.Email && u.Password == usuario.Password);
				if (us != null)
				{
					return RedirectToAction("Index", "Dashboard");
				}
			}
			return View("Index",usuario);
		}

	}
}
