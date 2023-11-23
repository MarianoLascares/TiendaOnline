using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaFunko.Models;

namespace TiendaFunko.Controllers
{
    public class FacturaProductoController : Controller
    {
        private readonly TiendaFunkoContext context;

        public FacturaProductoController(TiendaFunkoContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Delete(int id)
        {
            var item = await context.FacturaProducto.Where(x => x.Id == id)
                .Include(fp => fp.FacturacionNavigation)
                .FirstOrDefaultAsync();
            if(item == null)
            {
                return BadRequest();
            }

            item.FacturacionNavigation.Total -= item.Total;
            item.FacturacionNavigation.Subtotal -= item.Total;
            await context.SaveChangesAsync();

            context.FacturaProducto.Remove(item);
            await context.SaveChangesAsync();

            return RedirectToAction("Cart", "Facturacion");
        }
    }
}
