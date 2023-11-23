using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TiendaFunko.Models.Configurations
{
    public class FacturaProductoConfiguration : IEntityTypeConfiguration<FacturaProducto>
    {
        public void Configure(EntityTypeBuilder<FacturaProducto> builder)
        {
            //builder.HasKey(fp => new { fp.FacturacionId, fp.FunkoId }).HasName("PK_FacturaProducto");
        }
    }
}
