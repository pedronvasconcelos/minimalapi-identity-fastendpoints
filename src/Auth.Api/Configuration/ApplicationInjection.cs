using Auth.Application.Services;

namespace Auth.Api.Configuration;

public static class ApplicationInjection
{
    public static IServiceCollection InjectApplication(this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();
        return services;
    }       
}
