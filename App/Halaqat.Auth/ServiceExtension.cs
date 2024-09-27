using Microsoft.Extensions.DependencyInjection;

namespace Halaqat.Auth
{
    public static class ServiceExtension
    {
        public static IServiceCollection ConfigureAuthFeature(this IServiceCollection services)
        {
            services.AddTransient<Login.ViewModel>();
            services.AddTransient<Shared.Abstraction.Features.Auth.ILoginView, Login.View>();
            return services;
        }
    }
}
