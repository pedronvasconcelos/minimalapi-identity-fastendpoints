using Auth.Application.Login;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace Auth.Api.Endpoints;

[HttpPost("/login"), AllowAnonymous]
public class LoginUserEndpoint : Endpoint<LoginRequest, LoginResponse>
{
    private readonly LoginUserHandler _handler;

    public LoginUserEndpoint(LoginUserHandler handler)
    {
        _handler = handler;
    }

    public override async Task HandleAsync(LoginRequest request, CancellationToken ct)
    {
        var result = await _handler.Handle(request);
        await SendOkAsync(result);
    }
}
