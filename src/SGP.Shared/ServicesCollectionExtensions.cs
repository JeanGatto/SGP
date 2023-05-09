using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using SGP.Shared.Abstractions;
using SGP.Shared.AppSettings;
using SGP.Shared.Constants;

namespace SGP.Shared;

[ExcludeFromCodeCoverage]
public static class ServicesCollectionExtensions
{
    public static void ConfigureAppSettings(this IServiceCollection services)
    {
        services.AddOptions<AuthOptions>(AppSettingsKeys.AuthOptions);
        services.AddOptions<CacheOptions>(AppSettingsKeys.CacheOptions);
        services.AddOptions<ConnectionStrings>(AppSettingsKeys.ConnectionStrings);
        services.AddOptions<InMemoryOptions>(AppSettingsKeys.InMemoryOptions);
        services.AddOptions<JwtOptions>(AppSettingsKeys.JwtOptions);
    }

    private static void AddOptions<TOptions>(this IServiceCollection services, string configSectionPath)
        where TOptions : class, IAppOptions
    {
        services
            .AddOptions<TOptions>()
            .BindConfiguration(configSectionPath, options => options.BindNonPublicProperties = true)
            .ValidateDataAnnotations()
            .ValidateOnStart();
    }
}