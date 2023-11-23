using Microsoft.AspNetCore.Mvc;
using TiendaFunko.Models;

namespace TiendaFunko.Controllers
{
    public class CasificacionController : Controller
    {
        private readonly TiendaFunkoContext context;

        public CasificacionController(TiendaFunkoContext context)
        {
            this.context = context;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id, Descripcion")] Clasificacion clasificacion)
        {
            if (ModelState.IsValid)
            {
                context.Add(clasificacion);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(clasificacion);
        }
    }
}
