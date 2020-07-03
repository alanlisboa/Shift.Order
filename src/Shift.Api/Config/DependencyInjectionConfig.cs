using Microsoft.Extensions.DependencyInjection;
using Shift.Infrastructure.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shift.Api.Config
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
