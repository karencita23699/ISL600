using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto.Models.BD;

namespace PROYECTO_SIL600.Controllers
{
    public class DashboardController : Controller
    {
        DbFutbolContext _context;
        public DashboardController(DbFutbolContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Campeonato> lista = await _context.Campeonatos.ToListAsync();
            return View(lista);
        }
        public IActionResult Registrar()
        {
            return View(new Campeonato());
        }
    }
}
