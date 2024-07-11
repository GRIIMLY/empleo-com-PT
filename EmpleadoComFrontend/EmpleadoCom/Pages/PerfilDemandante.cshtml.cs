using EmpleadoComFrontend.Models;
using EmpleadoComFrontend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmpleadoComFrontend.Pages
{
    public class PerfilDemandanteModel : PageModel
    {
        [BindProperty]
        public DemandanteModel demandante { get; set; }
        [BindProperty]
        public List<int> habilidadesSeleccionadas { get; set; }
        [BindProperty]
        public bool esEdicion { get; set; }
        private readonly DemandanteService _demandanteService;
        private readonly HabilidadService _habilidadService;
        private readonly HabilidadUsuarioTrabajoService _habilidadUsuarioTrabajoService;
        public List<HabilidadModel> habilidades = new List<HabilidadModel>();



        public PerfilDemandanteModel(DemandanteService demandanteService, HabilidadService habilidadService, HabilidadUsuarioTrabajoService habilidadUsuarioTrabajoService)
        {
            _demandanteService = demandanteService;
            _habilidadService = habilidadService;
            _habilidadUsuarioTrabajoService = habilidadUsuarioTrabajoService;
            this.habilidadesSeleccionadas = new List<int>();
        }
        //public void OnGet()
        //{
        //}

        public async Task OnGetAsync()
        {
            habilidades = await _habilidadService.GetHabilidades();
            await this.PrecargarDatosAEditar();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var result = false;
            demandante.DemandanteId = Int32.Parse(HttpContext.Session.GetString("UsuarioId"));
            if (this._demandanteService.GetPerfilPorId(Int32.Parse(HttpContext.Session.GetString("UsuarioId"))).Result.Nombre == null)
            {
                result = await _demandanteService.CrearPerfil(demandante);
            }
            else
            {
                result = await _demandanteService.ActualizarPerfil(demandante);
            }

            if (result)
            {
                RegistrarHabilidades(this.habilidadesSeleccionadas);
                TempData["SuccessMessage"] = "Perfil creado exitosamente!";
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Hay un error al crear el perfil.");
                return Page();
            }

            return RedirectToPage("/Index");
        }

        public async void RegistrarHabilidades(List<int> habilidadesSeleccionadas)
        {
            await this._habilidadUsuarioTrabajoService.DeleteHabilidadPorIdUsuario(Int32.Parse(HttpContext.Session.GetString("UsuarioId")));
            var habilidadesAGuardar = new List<HabilidadUsuarioTrabajoModel>();
            foreach (var habilidad in habilidadesSeleccionadas)
            {
                var habilidadUsuario = new HabilidadUsuarioTrabajoModel();
                habilidadUsuario.HabilidadId = habilidad;
                habilidadUsuario.UsuarioId = Int32.Parse(HttpContext.Session.GetString("UsuarioId"));
                habilidadesAGuardar.Add(habilidadUsuario);
            }
            await this._habilidadUsuarioTrabajoService.RegistrarListadoHabilidadUsuarioTrabajo(habilidadesAGuardar);

        }

        public async Task PrecargarDatosAEditar()
        {
            this.demandante = await this._demandanteService.GetPerfilPorId(Int32.Parse(HttpContext.Session.GetString("UsuarioId")));
            this.habilidadesSeleccionadas = this._habilidadService.GetHabilidadesPorIdUsuario(Int32.Parse(HttpContext.Session.GetString("UsuarioId"))).Result.Select(habilidad => habilidad.HabilidadId).ToList();

        }
    }
}
