using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Services
{
    public static class CodingToolsBootstrapper
    {
        public static IServiceProvider AddCodingTools(
           this IServiceCollection services,
           Assembly signalRAssembly,
           IConfiguration configuration)
        {
            services.AddSingleton(configuration);


            services.AddMediatR(typeof(CodingToolsBootstrapper).Assembly, signalRAssembly);

            return services.BuildServiceProvider();
        }
    }
}
