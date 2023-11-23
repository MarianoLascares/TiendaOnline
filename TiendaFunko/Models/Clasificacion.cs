namespace TiendaFunko.Models
{
    public class Clasificacion
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public List<Funko> Funko {  get; set; } = new List<Funko>();
    }
}
