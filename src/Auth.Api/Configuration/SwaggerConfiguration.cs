
namespace Auth.Api.Configuration;

public static class SwaggerConfiguration
{
    public static IApplicationBuilder ConfigureSwagger(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Auth API V1");
        });
        return app;
    }

    
}
