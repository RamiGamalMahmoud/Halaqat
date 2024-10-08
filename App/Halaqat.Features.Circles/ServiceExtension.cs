using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Halaqat.Features.Circles
{
    public static class ServiceExtension
    {
        public static IServiceCollection ConfigureCirclesFeature(this IServiceCollection services)
        {
            services.AddMediatR((cfg) => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddSingleton<Repository>();

            services.AddSingleton<Shared.Abstraction.Features.Circles.IHomeView, Home.View>();
            services.AddSingleton<Home.ViewModel>();

            services.AddSingleton<Editor.CreateViewModel>();
            services.AddSingleton<Editor.UpdateViewModel>();
            return services;
        }
    }
}
