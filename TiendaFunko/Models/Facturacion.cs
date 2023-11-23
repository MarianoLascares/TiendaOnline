namespace TiendaFunko.Models
{
    public class Facturacion
    {
        public int Id { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public int UsuarioId { get; set; }
        public Usuario UsuarioNavigation { get; set; } = null!;
        public List<FacturaProducto> FacturaProductoNavigation { get; set; } = new List<FacturaProducto>();
        public int Estado { get; set; } = 0;
    }
}
