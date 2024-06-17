using Microsoft.AspNetCore.Mvc;

namespace PROYECTO_SIL600.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
