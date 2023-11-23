namespace TiendaFunko.Models
{
    public class Funko
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Img { get; set; } = null!;
        public string DescriptionImg { get; set; } = null!;
        public string ImgCaja { get; set; } = null!;
        public string DescriptionImgCaja { get; set; } = null!;
        public decimal Price { get; set; }
        public string? SKU { get; set; } = null!;
        public int Stock {  get; set; }
        public int ClasificacionId { get; set; }
        public Clasificacion ClasificacionNavigation { get; set;} = null!;
        public List<FacturaProducto> FacturaProductoNavigation { get; set; } = new List<FacturaProducto>();
    }
}
