using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Halaqat.Features.Programs
{
    public static class ServiceExtension
    {
        public static IServiceCollection ConfigureProgramsFeature(this IServiceCollection services)
        {
            services.AddMediatR((cfg) => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddSingleton<Repository>();

            services.AddSingleton<Home.ViewModel>();
            services.AddSingleton<Shared.Abstraction.Features.Programs.IHomeView, Home.View>();

            return services;
        }
    }
}
