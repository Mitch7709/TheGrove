using System;
using API.Configuration;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace API.Extensions;

public static class DBExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>((serviceProvider, options) =>
        {
            var dbOptions = serviceProvider.GetRequiredService<IOptions<DBOptions>>().Value;

            options.UseSqlServer(dbOptions.ConnectionString, sqlOptions =>
            {
                sqlOptions.CommandTimeout(dbOptions.CommandTimeout);
                sqlOptions.EnableRetryOnFailure(dbOptions.MaxRetryCount);
            });
        });
        return services;
    }

    public static IApplicationBuilder UseDatabase(this IApplicationBuilder app)
    {
        if (app is not WebApplication webApp) {
            throw new InvalidOperationException("UseDatabase can only be called on a WebApplication instance.");
        }

        using var scope = webApp.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        dbContext.Database.Migrate();

        return app;
    }
}
