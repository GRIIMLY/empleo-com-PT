using EmpleadoComFrontend.Models;
using EmpleadoComFrontend.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmpleadoComFrontend.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public UsuarioModel User { get; set; }
        private readonly UsuarioService _userService;

        public RegisterModel(UsuarioService userService)
        {
            _userService = userService;
        }


        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if(await _userService.UsuarioPorNombreUsuario(User.NombreUsuario) != null)
            {
                TempData["SuccessMessage"] = "Usuario existente!";
                return Page();
            };

            var result = await _userService.RegisterUser(User);

            if (result)
            {
                TempData["SuccessMessage"] = "Usuario registrado exitosamente!";
            }
            else
            {
                ModelState.AddModelError(string.Empty, "There was an error registering the user.");
                return Page();
            }

            return RedirectToPage("/Index");
        }
    }
}
