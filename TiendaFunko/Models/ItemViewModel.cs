namespace TiendaFunko.Models
{
    public class ItemViewModel
    {
        public Funko FunkoPrincipal { get; set; } = null!;
        public List<Funko> FunkosRelacionados { get; set; } = new List<Funko>();
    }
}
