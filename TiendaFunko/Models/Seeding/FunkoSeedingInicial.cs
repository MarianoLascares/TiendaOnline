using Microsoft.EntityFrameworkCore;

namespace TiendaFunko.Models.Seeding
{
    public class FunkoSeedingInicial
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            Funko Stormtrooper = new Funko()
            {
                Id = 1,
                Name = "Stormtrooper Lightsaber",
                Description = "Figura coleccionable Funko de un Stromtrooper",
                Img = "../../img/star-wars/trooper-1.webp",
                DescriptionImg = "Figura coleccionable Funko de un Stromtrooper",
                ImgCaja= "../../img/star-wars/trooper-box.webp",
                DescriptionImgCaja = "Figura coleccionable Funko de un Stromtrooper en caja",
                Price = 1799.99m,
                SKU = "STW001004",
                Stock = 15,
                ClasificacionId = 1
            };

            Funko Pidgeotto = new Funko()
            {
                Id = 2,
                Name = "Pidgeotto",
                Description = "Figura coleccionable Funko de Pidgeotto",
                Img = "../../img/pokemon/pidgeotto-1.webp",
                DescriptionImg = "Figura coleccionable Funko de Pidgeotto",
                ImgCaja = "../../img/pokemon/pidgeotto-box.webp",
                DescriptionImgCaja = "Figura coleccionable Funko de Pidgeotto en caja",
                Price = 1799.99m,
                SKU = "PKM001003",
                Stock = 15,
                ClasificacionId = 2
            };
            Funko Luna = new Funko()
            {
                Id = 3,
                Name = "Luna Lovegood Lion Mask",
                Description = "Figura coleccionable Funko de Luna Lovegood",
                Img = "../../img/harry-potter/luna-1.webp",
                DescriptionImg = "Figura coleccionable Funko de Luna Lovegood",
                ImgCaja = "../../img/harry-potter/luna-box.webp",
                DescriptionImgCaja = "Figura coleccionable Funko de Luna Lovegood en caja",
                Price = 1799.99m,
                SKU = "HPT001003",
                Stock = 15,
                ClasificacionId = 3
            };
            Funko Charmander = new Funko()
            {
                Id = 4,
                Name = "Charmander",
                Description = "Figura coleccionable Funko de Charmander",
                Img = "../../img/pokemon/charmander-1.webp",
                DescriptionImg = "Figura coleccionable Funko de Charmander",
                ImgCaja = "../../img/pokemon/charmander-box.webp",
                DescriptionImgCaja = "Figura coleccionable Funko de Charmander en caja",
                Price = 1799.99m,
                SKU = "PKM001001",
                Stock = 15,
                ClasificacionId = 2
            };
            Funko Harry = new Funko()
            {
                Id = 5,
                Name = "Harry Potter",
                Description = "Figura coleccionable Funko de Harry Potter",
                Img = "../../img/harry-potter/harry-1.webp",
                DescriptionImg = "Figura coleccionable Funko de Harry Potter",
                ImgCaja = "../../img/harry-potter/harry-box.webp",
                DescriptionImgCaja = "Figura coleccionable Funko de Harry Potter en caja",
                Price = 1799.99m,
                SKU = "HPT001001",
                Stock = 15,
                ClasificacionId = 3
            };
            Funko BabyYoda = new Funko()
            {
                Id = 6,
                Name = "Baby Yoda",
                Description = "Figura coleccionable Funco de Baby Yoda",
                Img = "../../img/star-wars/baby-yoda-1.webp",
                DescriptionImg = "Figura coleccionable Funco de Baby Yoda",
                ImgCaja = "../../img/star-wars/baby-yoda-box.webp",
                DescriptionImgCaja = "Figura coleccionable Funco de Baby Yoda en caja",
                Price = 1799.99m,
                SKU = "STW001001",
                Stock = 15,
                ClasificacionId = 1
            };

            modelBuilder.Entity<Funko>().HasData(Stormtrooper, Pidgeotto, Luna, Charmander, Harry, BabyYoda);
        }
    }
}
