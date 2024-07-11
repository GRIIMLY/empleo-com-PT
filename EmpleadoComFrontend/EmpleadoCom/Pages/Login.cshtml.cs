using EmpleadoComFrontend.Models;
using EmpleadoComFrontend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmpleadoComFrontend.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Models.LoginModel Usuario { get; set; }

        private readonly UsuarioService _usuarioService;

        public LoginModel(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        public void OnGet()
        {
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var usuarioValido = await _usuarioService.ValidarUsuario(Usuario.NombreUsuario, Usuario.Contrasenia);
            // Guardar en TempData
            //TempData["TipoUsuario"] = usuarioValido.TipoUsuario;
            //TempData["NombreUsuario"] = usuarioValido.NombreUsuario;
            //TempData["UsuarioId"] = usuarioValido.UsuarioId;
         

            if (usuarioValido != null)
            {
                HttpContext.Session.SetString("TipoUsuario", usuarioValido.TipoUsuario);
                HttpContext.Session.SetString("NombreUsuario", usuarioValido.NombreUsuario);
                HttpContext.Session.SetString("UsuarioId", usuarioValido.UsuarioId.ToString());
                // Manejar la redirección después del login exitoso
                return RedirectToPage("/Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Nombre de usuario o contraseña incorrectos.");
                return Page();
            }
        }
    }
}
