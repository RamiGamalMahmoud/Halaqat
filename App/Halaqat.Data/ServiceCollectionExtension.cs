using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Halaqat.Data
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection ConfigureData(this IServiceCollection services)
        {
            services.AddMediatR((cfg) => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
