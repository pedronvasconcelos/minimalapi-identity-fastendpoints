using Auth.Application.IdentitySettings;
using FastEndpoints.Security;


namespace Auth.Api.Configuration;

public static class JwtConfiguration
{
    public static IServiceCollection ConfigureJWT(this IServiceCollection services, JwtSettings? jwtSettings)
    {
        if (jwtSettings is null)
        {
            throw new ArgumentNullException(nameof(jwtSettings));
        }       
        services.AddAuthenticationJwtBearer(x => x.SigningKey = jwtSettings.Secret);
        return services;
    }
}
