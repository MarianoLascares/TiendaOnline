namespace TiendaFunko.Models
{
    public class FacturaProducto
    {
        public int Id { get; set; }
        public int FacturacionId { get; set; }
        public int FunkoId { get; set; }
        public Facturacion FacturacionNavigation { get; set; } = null!;
        public Funko FunkoNavigation { get; set; } = null!;
        public int Cantidad {  get; set; }
        public decimal Total { get; set; }
    }
}
