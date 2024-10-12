using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Halaqat.Features.MemorizingAndReview
{
    public static class ServiceExtension
    {
        public static IServiceCollection ConfigureMemorizingAndReviewFeature(this IServiceCollection services)
        {
            services.AddMediatR((cfg) => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
