using EmpleoComRepository.Repositories;
using EmpleoComRepository.Repositories.Implements;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Repositories;

namespace EmpleoComRepository.Middleware
{
    public static class IoCRepositories
    {
        public static IServiceCollection addDependency(this IServiceCollection services)
        {
            #region Repositories Conatainer
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IDemandantesRepository), typeof(DemandanteRepository));
            services.AddScoped(typeof(IDescripcionesTrabajoRepository), typeof(DescripcionesTrabajoRepository));
            services.AddScoped(typeof(IEmparejamientosRepository), typeof(EmparejamientosRepository));
            services.AddScoped(typeof(IEmpleadoresRepository), typeof(EmpleadoresRepository));
            services.AddScoped(typeof(IUsuariosRepository), typeof(UsuariosRepository));
            services.AddScoped(typeof(IHabilidadRepository), typeof(HabilidadRepository));
            services.AddScoped(typeof(HabilidadUsuarioTrabajoRepository), typeof(HabilidadUsuarioRepository));

            #endregion
            return services;
        }
    }
}
