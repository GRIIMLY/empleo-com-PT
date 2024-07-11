
using EmpleoComBI.BI;
using EmpleoComBI.BI.Implements;
using EmpleoComRepository.Repositories;
using EmpleoComRepository.Repositories.Implements;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Repositories;

namespace EmpleoComBI.Middleware
{
    public static class IoCBI
    {
        public static IServiceCollection addDependency(this IServiceCollection services)
        {
            #region Services Container
       
            services.AddScoped(typeof(IGenericBI<>), typeof(GenericBI<>));
            services.AddScoped(typeof(IUsuariosBI), typeof(UsuariosBI));
            services.AddScoped(typeof(IDemandantesBI), typeof(DemandantesBI));
            services.AddScoped(typeof(IDescripcionesTrabajoBI), typeof(DescripcionesTrabajoBI));
            services.AddScoped(typeof(IEmparejamientosBI), typeof(EmparejamientosBI));
            services.AddScoped(typeof(IEmpleadoresBI), typeof(EmpleadoresBI));
            services.AddScoped(typeof(IHabilidadBI), typeof(HabilidadBI));
            services.AddScoped(typeof(IHabilidadUsuarioBI), typeof(HabilidadUsuarioBI));

            #endregion

            return services;
        }

    }
}
