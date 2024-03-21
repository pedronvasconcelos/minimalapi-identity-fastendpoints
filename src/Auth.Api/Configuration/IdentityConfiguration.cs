using Auth.Identity.Models;
using Auth.Infrastructure.Database;
using Microsoft.AspNetCore.Identity;
namespace Auth.Api.Configuration;

public static class IdentityConfiguration
{
    public static IServiceCollection AddAuthConfiguration(this IServiceCollection services)
    {

        services.AddIdentity<ApplicationUser, ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddSignInManager()
            .AddDefaultTokenProviders();

        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 8;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 10;
            options.Lockout.AllowedForNewUsers = true;
            options.User.RequireUniqueEmail = true;

        });
        services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
        services.AddAuthorizationBuilder();
        return services;
    }   
}
