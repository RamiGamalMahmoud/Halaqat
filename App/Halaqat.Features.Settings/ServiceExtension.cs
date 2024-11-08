using Halaqat.Shared;
using Halaqat.Shared.Abstraction.Features.Settings;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Halaqat.Features.Settings
{
    public static class ServiceExtension
    {
        public static IServiceCollection ConfigureSettingsFeature(this IServiceCollection services)
        {
            services.AddMediatR((cfg) => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddSingleton<DatabaseOperations>();

            services.AddSingleton<Properties.Settings>(Properties.Settings.Default);

            services.AddTransient<Shared.Abstraction.Features.Settings.IDatabaseConfigurationView, DatabaseConfiguration.View>();
            services.AddTransient<DatabaseConfiguration.ViewModel>();

            services.AddTransient<ISettingsView, View>();
            services.AddSingleton<ISettingsVewModel, ViewModel>();

            return services;
        }
    }
}
