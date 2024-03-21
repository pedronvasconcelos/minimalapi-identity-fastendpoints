using Auth.Identity.Models;
using Auth.Infrastructure.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Auth.Api.Configuration;

public static class DbConfiguration
{
    public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ApplicationDbContext>(options =>
         options.UseMySql(connectionString,
           ServerVersion.AutoDetect(connectionString),
           b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)),

       ServiceLifetime.Transient);

        return services;

    }
}
