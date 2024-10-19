using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Halaqat.Features.MemorizingAndReview
{
    public static class ServiceExtension
    {
        public static IServiceCollection ConfigureMemorizingAndReviewFeature(this IServiceCollection services)
        {
            services.AddMediatR((cfg) => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddSingleton<Repository>();

            services.AddTransient<View>();
            services.AddTransient<ViewModel>();

            return services;
        }
    }
}
