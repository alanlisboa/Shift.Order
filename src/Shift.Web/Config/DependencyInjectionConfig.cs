using System;
using Microsoft.Extensions.DependencyInjection;
using Shift.Infrastructure.IoC;

namespace Shift.Web.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            InjectorBootStrapper.RegisterServices(services);
        }
    }
}