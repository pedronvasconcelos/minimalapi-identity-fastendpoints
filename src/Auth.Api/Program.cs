
using Auth.Api.Configuration;
using Auth.Api.Middleware;
using Auth.Application.IdentitySettings;
using FastEndpoints;
 
var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDatabaseConfiguration(builder.Configuration)
    .AddFastEndpoints()
    .AddEndpointsApiExplorer()
    .SwaggerGenConfigure()
    .AddAuthConfiguration()
    .BindJwt(builder.Configuration)
    .ConfigureJWT(builder.Configuration.Get<JwtSettings>())
    .InjectApplication();



builder.Host.ConfigureWolverine();
builder.Host.ConfigureLogger();
var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection()
    .UseAuthentication()
    .UseAuthorization()
    .UseFastEndpoints()
    .ConfigureSwagger();

app.Run();
     