using Auth.Application.IdentitySettings;

namespace Auth.Api.Configuration;

public static class JwtBinder
{
    public static IServiceCollection BindJwt(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(nameof(JwtSettings), jwtSettings);
        services.AddSingleton(jwtSettings);
        return services;
    }       
}
