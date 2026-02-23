using System;

namespace API.Configuration;

public static class ConfigurationExtensions
{
    public static IServiceCollection AddCustomConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<DBOptions>()
        .Bind(configuration.GetSection("Database"))
        .ValidateDataAnnotations();

        return services;
    }
}
