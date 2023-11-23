namespace TiendaFunko.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public int Credencial {  get; set; } = 0;
        public Facturacion FacturacionNavigation { get; set; } = null!;
    }
}
