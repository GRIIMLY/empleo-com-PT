using EmpleadoComFrontend.Models;
using EmpleadoComFrontend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmpleadoCom.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<DescripcionTrabajoModel> descripcionTrabajoModels { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Habilidades { get; set; }

        private readonly ILogger<IndexModel> _logger;
        private readonly DescripcionesTrabajoService _descripcionesTrabajoService;

        public IndexModel(DescripcionesTrabajoService descripcionesTrabajoService, ILogger<IndexModel> logger)
        {
            _descripcionesTrabajoService = descripcionesTrabajoService;
            _logger = logger;
        }
   

        //public void OnGet()
        //{
        //    this.descripcionTrabajoModels = this._descripcionesTrabajoService.GetResumenDescripcionTrabajo().Result;

        //}

        public async Task OnGetAsync()
        {
            if (!string.IsNullOrEmpty(Habilidades))
            {
                this.descripcionTrabajoModels = await _descripcionesTrabajoService.GetResumenDescripcionTrabajo();
                var palabrasHabilidades = Habilidades.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                descripcionTrabajoModels = descripcionTrabajoModels.Where(trabajo =>
                {
                    var todasHabilidades = string.Join(" ", trabajo.HabilidadesRequeridas).ToLower();
                    var titulos = string.Join(" ", trabajo.TituloTrabajo).ToLower();
                    return palabrasHabilidades.All(palabra => todasHabilidades.Contains(palabra.ToLower()) || titulos.Contains(palabra.ToLower()));
                }).ToList();

            }
            else
            {
                this.descripcionTrabajoModels = await _descripcionesTrabajoService.GetResumenDescripcionTrabajo();
            }
        }
    }
}