using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using TiendaFunko.Models.Seeding;

namespace TiendaFunko.Models
{
    public class TiendaFunkoContext : DbContext
    {
        public TiendaFunkoContext(DbContextOptions<TiendaFunkoContext> options) : base(options)
        {

        }

        public DbSet<Funko> Funko { get; set; }
        public DbSet<Clasificacion> Clasificacion { get; set; }
        public DbSet<Facturacion> Facturacion { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<FacturaProducto> FacturaProducto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            ClasificacionSeedingInicial.Seed(modelBuilder);
            FunkoSeedingInicial.Seed(modelBuilder);
            UsuarioSeedingInicial.Seed(modelBuilder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveMaxLength(150);
        }
    }
}
