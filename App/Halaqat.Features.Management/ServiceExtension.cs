using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Halaqat.Features.Management
{
    public static class ServiceExtension
    {
        public static IServiceCollection ConfigureManagementFeature(this IServiceCollection services)
        {
            services.AddMediatR((cfg) => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddSingleton<AcademicQualifications.Repository>();

            services.AddSingleton<Cities.Repository>();
            services.AddSingleton<Cities.Home.View>();
            services.AddSingleton<Cities.Home.ViewModel>();

            services.AddSingleton<Shared.Abstraction.Features.Management.IHomeView, Home.View>();
            services.AddSingleton<Home.ViewModel>();

            return services;
        }
    }
}
