using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Halaqat.Features.Users
{
    public static class ServiceExtension
    {
        public static IServiceCollection ConfigureUsersFeature(this IServiceCollection services)
        {
            services.AddMediatR((cfg) => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddSingleton<Repository>();

            services.AddSingleton<Shared.Abstraction.Features.Users.IHomeView, Home.View>();
            services.AddSingleton<Home.ViewModel>();

            return services;
        }
    }
}
