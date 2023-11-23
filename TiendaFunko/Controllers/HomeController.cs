using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TiendaFunko.Models;

namespace TiendaFunko.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TiendaFunkoContext context;

        public HomeController(ILogger<HomeController> logger, TiendaFunkoContext context)
        {
            _logger = logger;
            this.context = context;
        }

        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var funkosRecientes = await context.Funko.OrderByDescending(f => f.Id)
                .Take(6)
                .ToListAsync();
            return View(funkosRecientes);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}