using Serilog;
namespace Auth.Api.Configuration;

public static class LogConfiguration
{
    public static void ConfigureLogger(this ConfigureHostBuilder builder)
    {
        builder.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
    .ReadFrom.Configuration(hostingContext.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console());
    }
}