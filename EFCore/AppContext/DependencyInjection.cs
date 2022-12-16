using EFCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EFCore.AppContext;

public static class DependencyInjection
{
    public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));

            options.EnableDetailedErrors();
            options.EnableSensitiveDataLogging();
        });

        services.AddScoped<IAppDbContext>(provider => provider.GetService<AppDbContext>());

        return services;
    }
}