using Auth.Application.Exceptions;
using System.Runtime.CompilerServices;
using Wolverine;
using Wolverine.Attributes;
using Wolverine.ErrorHandling;
namespace Auth.Api.Configuration;

public static class WolverineConfiguration
{
    public static void ConfigureWolverine(this ConfigureHostBuilder builder)
    {
        builder.UseWolverine();
    }
}
