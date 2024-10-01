using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Halaqat.Features.Employees
{
    public static class ServiceExtension
    {
        public static IServiceCollection ConfigureEmployeesFeature(this IServiceCollection services)
        {
            services.AddMediatR((cfg) => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddSingleton<Repository>();
            services.AddSingleton<Teachers.Repository>();

            services.AddSingleton<Shared.Abstraction.Features.Employees.IHomeView, Home.View>();
            services.AddSingleton<Home.ViewModel>();

            services.AddSingleton<Editor.CreateViewModel>();
            services.AddSingleton<Editor.UpdateViewModel>();
            return services;
        }
    }
}
