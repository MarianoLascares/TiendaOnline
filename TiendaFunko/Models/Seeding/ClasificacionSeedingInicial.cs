using Microsoft.EntityFrameworkCore;

namespace TiendaFunko.Models.Seeding
{
    public class ClasificacionSeedingInicial
    {
        public static void Seed (ModelBuilder modelBuilder)
        {
            Clasificacion StarWars = new Clasificacion()
            {
                Id = 1,
                Descripcion = "Star Wars"
            };
            Clasificacion Pokemon = new Clasificacion()
            {
                Id = 2,
                Descripcion = "Pokemon"
            };
            Clasificacion HarryPoter = new Clasificacion()
            {
                Id = 3,
                Descripcion = "Harry Poter"
            };
            modelBuilder.Entity<Clasificacion>().HasData(StarWars, Pokemon, HarryPoter);
        }
    }
}
