using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaFunko.Models;

namespace TiendaFunko.Controllers
{
    public class FacturacionController : Controller
    {
        private readonly TiendaFunkoContext context;

        public FacturacionController(TiendaFunkoContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            // Obtener el ID del usuario desde la sesión
            var userIdFromSession = HttpContext.Session.GetInt32("id");

            if (userIdFromSession == null)
            {
                // Manejar el caso en que el ID de usuario no esté en la sesión o no se pueda convertir a un entero
                return RedirectToAction("Login", "Usuario");
            }

            var cart = await context.Facturacion
                .Include(f => f.FacturaProductoNavigation)
                .ThenInclude(fp => fp.FunkoNavigation)
                .Where(f => f.UsuarioId == userIdFromSession && f.Estado == 0)
                .FirstOrDefaultAsync();

            if (cart == null)
            {
                cart = new Facturacion()
                {
                    UsuarioId = (int)userIdFromSession
                };
                context.Facturacion.Add(cart);
                await context.SaveChangesAsync();
            return View(cart);
            }

            return View(cart);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int idUser, int idFunko)
        {
            var facturacion = await context.Facturacion
                .Where(f => f.UsuarioId == idUser && f.Estado == 0)
                .FirstOrDefaultAsync();

            var funko = await context.Funko
                .Where(f => f.Id == idFunko)
                .FirstOrDefaultAsync();

            if (funko == null)
            {
                return NotFound("El Funko no se encontró.");
            }

            if (facturacion == null)
            {
                facturacion = new Facturacion()
                {
                    UsuarioId = idUser
                };
                context.Facturacion.Add(facturacion);
                await context.SaveChangesAsync();
            }

            bool existeElFunko = context.FacturaProducto.Any(e => e.FunkoId == idFunko);

            if(existeElFunko)
            {
                var facturaProductoExistente = context.FacturaProducto.FirstOrDefault(f=> f.FunkoId == idFunko);
                if (facturaProductoExistente == null)
                {
                    return BadRequest();
                }
                facturaProductoExistente.Cantidad++;
                facturaProductoExistente.Total = funko.Price * facturaProductoExistente.Cantidad;
            }
            else
            {
                FacturaProducto facturaProducto = new FacturaProducto();
                facturaProducto.FacturacionId = facturacion.Id;
                facturaProducto.FunkoId = idFunko;
                facturaProducto.Cantidad = 1;
                facturaProducto.Total = funko.Price * facturaProducto.Cantidad;

                context.FacturaProducto.Add(facturaProducto);
            }
            await context.SaveChangesAsync();

            //facturacion.FacturaProductoNavigation.Add(facturaProducto);
            facturacion.Subtotal = await context.FacturaProducto
                .Where(fp => fp.FacturacionId == facturacion.Id)
                .SumAsync(fp => fp.Total);
            facturacion.Total = facturacion.Subtotal;
            await context.SaveChangesAsync();


            return RedirectToAction(nameof(Cart), new { idUser = idUser });
        }
    }
}
