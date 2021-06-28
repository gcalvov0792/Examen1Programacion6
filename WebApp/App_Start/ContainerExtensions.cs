using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BD;
using WBL;


namespace WebApp
{
    public static class ContainerExtensions
    {

        public static IServiceCollection AddDIContainer(this IServiceCollection services)
        {
            //cosas que se necesitan instancial desde el inicio
            services.AddSingleton<IDataAccess, DataAccess>();

            //cosas que no se necesitan instanciar desde el inicio
            services.AddTransient<IDepartamentosService, DepartamentosService>();
            services.AddTransient<IPuestosService, PuestosService>();
            services.AddTransient<ITitulosService, TitulosService>();

            return services;
        }
    }
}
