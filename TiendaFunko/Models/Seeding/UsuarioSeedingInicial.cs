using Microsoft.EntityFrameworkCore;

namespace TiendaFunko.Models.Seeding
{
    public class UsuarioSeedingInicial
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            Usuario Mariano = new Usuario()
            {
                Id = 1,
                Nombre = "Mariano",
                Apellido = "Lascares",
                Password = "BBAF85A574B5B26907872548398B034EDB8DD7D794CE74D4E4461EBFA6224581", //190115
                Email = "mariano.lascares@gmail.com",
                Direccion = "San Juan 1349",
                Credencial = 1
            };

            modelBuilder.Entity<Usuario>().HasData(Mariano);
        }
    }
}
