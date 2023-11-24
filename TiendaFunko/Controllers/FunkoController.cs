using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using TiendaFunko.Models;

namespace TiendaFunko.Controllers
{
    public class FunkoController : Controller
    {
        private readonly TiendaFunkoContext context;

        public FunkoController(TiendaFunkoContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Listado()
        {
            var funkosJson = TempData["Funkos"] as string;

            if (string.IsNullOrEmpty(funkosJson))
            {
                return View(await context.Funko.Include(fc => fc.ClasificacionNavigation).ToArrayAsync());
            }

            var jsonOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                MaxDepth = 64
            };

            var funkos = JsonSerializer.Deserialize<List<Funko>>(funkosJson, jsonOptions); // Convertir de nuevo a lista al recuperar

            return View(funkos);
        }

        public async Task<IActionResult> Shop()
        {
            var funkosJson = TempData["Funkos"] as string;

            if (string.IsNullOrEmpty(funkosJson))
            {
                return View(await context.Funko.Include(fc => fc.ClasificacionNavigation).ToArrayAsync());
            }

            var jsonOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve, // Preservar referencias para evitar ciclos
                MaxDepth = 64 // Establecer la profundidad máxima permitida
            };

            var funkos = JsonSerializer.Deserialize<List<Funko>>(funkosJson, jsonOptions); // Convertir de nuevo a lista al recuperar

            return View(funkos);
        }

        public IActionResult Item()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Item(int? id)
        {
            if (id == null || context.Funko == null)
            {
                return NotFound();
            }

            var funko = await context.Funko.Where(f => f.Id == id).FirstOrDefaultAsync();

            if (funko == null)
            {
                return NotFound();
            }
            var funkosRelacionados = await context.Funko
                .Where(f => f.ClasificacionId == funko.ClasificacionId)
                .ToListAsync();

            if (funkosRelacionados == null)
            {
                return NotFound();
            }

            var viewModel = new ItemViewModel
            {
                FunkoPrincipal = funko,
                FunkosRelacionados = funkosRelacionados
            };
            return View(viewModel);
        }

        public IActionResult Create()
        {
            ViewData["ListaClasificacion"] = new SelectList(context.Clasificacion, "Id", "Descripcion");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,Name,Description,Img,DescripcionImg,ImgCaja,DescripcionImgCaja,Price,SKU,Stock,ClasificacionId")] Funko funko,
            IFormFile imgFile, IFormFile imgCajaFile)
        {
            if (imgFile != null && imgFile.Length > 0)
            {
                // Procesar la imagen principal
                funko.Img = await GuardarImagen(imgFile);
            }

            if (imgCajaFile != null && imgCajaFile.Length > 0)
            {
                // Procesar la imagen de la caja
                funko.ImgCaja = await GuardarImagen(imgCajaFile);
            }

            if (String.IsNullOrEmpty(funko.DescriptionImg))
            {
                funko.DescriptionImg = "Imagen del funko sin caja";
            }

            if (String.IsNullOrEmpty(funko.DescriptionImgCaja))
            {
                funko.DescriptionImgCaja = "Imagen del funko con caja";
            }

            context.Add(funko);
            await context.SaveChangesAsync();

            return View(funko);
        }

        private async Task<string> GuardarImagen(IFormFile file)
        {
            // Genera un nombre único para la imagen o utiliza el nombre original
            var nombreUnico = Guid.NewGuid().ToString() + "_" + file.FileName;

            // Obtiene la ruta del directorio de imágenes en tu proyecto
            var rutaDirectorio = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img");

            // Combina la ruta del directorio con el nombre único del archivo
            var rutaArchivo = Path.Combine(rutaDirectorio, nombreUnico);

            // Guarda el archivo en el servidor
            using (var stream = new FileStream(rutaArchivo, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Devuelve la ruta relativa al directorio wwwroot
            return "../../img/" + nombreUnico;
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewData["ListaClasificacion"] = new SelectList(context.Clasificacion, "Id", "Descripcion");
            var funko = await context.Funko.FindAsync(id);

            if (funko == null)
            {
                return NotFound();
            }

            return View(funko);
        }

        [HttpPost]
        public async Task<IActionResult> Search(
            string searchString, string orderBy, int minPrice, 
            int maxPrice, bool nuevo, bool ofertas, bool especial, bool favoritos)
        {
            if(
                searchString == null &&
                orderBy == "value1" &&
                minPrice == 0 &&
                maxPrice == 0 &&
                nuevo == false &&
                ofertas == false &&
                especial == false &&
                favoritos == false
                )
            {
                return RedirectToAction("Shop");
            }

            if(maxPrice == 0)
            {
                maxPrice = 99999;
            }

            var resultados = await context.Funko
                .Include(f => f.ClasificacionNavigation)
                .Where(f => f.Name.Contains(searchString) || f.ClasificacionNavigation.Descripcion.Contains(searchString)
                        && (minPrice <= f.Price && f.Price <= maxPrice))
                .OrderBy(f => orderBy == "value1" ? f.Price : f.Id)
                .ToListAsync();

            var jsonOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve, // Preservar referencias para evitar ciclos
                MaxDepth = 64 // Establecer la profundidad máxima permitida
            };

            TempData["Funkos"] = JsonSerializer.Serialize(resultados, jsonOptions); // Convertir a JSON antes de almacenar en TempData

            return RedirectToAction("Shop");
        }

        [HttpPost]
        public async Task<IActionResult> SearchList(
            string searchString)
        {
            var resultados = await context.Funko
        .Include(f => f.ClasificacionNavigation)
        .Where(f => f.Name.Contains(searchString) || f.ClasificacionNavigation.Descripcion.Contains(searchString))
        .ToListAsync();

            var jsonOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve, // Preservar referencias para evitar ciclos
                MaxDepth = 64 // Establecer la profundidad máxima permitida
            };

            TempData["Funkos"] = JsonSerializer.Serialize(resultados, jsonOptions); // Convertir a JSON antes de almacenar en TempData

            return RedirectToAction("Listado");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name, Description, Img, DescripcionImg, ImgCaja, DescripcionImgCaja, Price, SKU, Stock, ClasificacionId")] Funko funko)
        {
            if (id != funko.Id)
            {
                return NotFound();
            }

            if (String.IsNullOrEmpty(funko.DescriptionImg))
            {
                funko.DescriptionImg = "Imagen del funko sin caja";
            }

            if (String.IsNullOrEmpty(funko.DescriptionImgCaja))
            {
                funko.DescriptionImgCaja = "Imagen del funko con caja";
            }

            context.Update(funko);
            await context.SaveChangesAsync();
            
            return RedirectToAction("Listado");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funko = await context.Funko.FirstOrDefaultAsync(p => p.Id == id);

            if (funko == null)
            {
                return NotFound();
            }

            return View(funko);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funko = await context.Funko.FindAsync(id);
            if (funko == null)
            {
                return NotFound();
            }

            context.Funko.Remove(funko);
            await context.SaveChangesAsync();

            return RedirectToAction("Listado");
        }
    }
}
