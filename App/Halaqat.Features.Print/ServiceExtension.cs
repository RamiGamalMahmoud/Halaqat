using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Halaqat.Features.Print
{
    public static class ServiceExtension
    {
        public static IServiceCollection ConfigurePrintFeature(this IServiceCollection services)
        {
            services.AddMediatR((cfg) => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
