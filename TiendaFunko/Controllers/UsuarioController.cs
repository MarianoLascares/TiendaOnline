using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using TiendaFunko.Models;

namespace TiendaFunko.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly TiendaFunkoContext context;

        public UsuarioController(TiendaFunkoContext context)
        {
            this.context = context;
        }
        public ActionResult Login()
        {
            return View();
        }

        public IActionResult Loguear(Usuario login)
        {
            //EncriptarPassword
            string passwordEncriptado = Encriptar(login.Password);
            var loginUsuario = context.Usuario
                .Where(l => l.Email == login.Email && l.Password == passwordEncriptado)
                .FirstOrDefault();

            if (loginUsuario != null)
            {
                HttpContext.Session.SetString("usuario", loginUsuario.Email); //variable de sesion
                HttpContext.Session.SetInt32("id", loginUsuario.Id);
                HttpContext.Session.SetInt32("credencial", loginUsuario.Credencial);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["errorLogin"] = "Los datos ingresados son incorrectos";
                return View("Login");
            }
        }

        public string Encriptar(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    sb.Append(bytes[i].ToString("x2")); //el x2 convierte binario en hexadecimal
                }
                return sb.ToString();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register([Bind("Id,Nombre,Apellido,Email,Password,Direccion")] Usuario usuario)
        {
            usuario.Password = Encriptar(usuario.Password);
            context.Add(usuario);
            await context.SaveChangesAsync();
            return RedirectToAction("Login", "Usuario");
        }
    }
}
