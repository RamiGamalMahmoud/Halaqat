using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Halaqat.Features.Students
{
    public static class ServiceExtension
    {
        public static IServiceCollection ConfigureStudentsFeature(this IServiceCollection services)
        {
            services.AddMediatR((cfg) => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddSingleton<Repository>();

            services.AddSingleton<Shared.Abstraction.Features.Students.IHomeView, Home.View>();
            services.AddSingleton<Home.ViewModel>();

            services.AddSingleton<Editor.CreateViewModel>();
            services.AddSingleton<Editor.UpdateViewModel>();
            return services;
        }
    }
}
