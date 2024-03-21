using Auth.Application.Register;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace Auth.Api.Endpoints;

[HttpPost("/register"), AllowAnonymous]
public class RegisterUserEndpoint : Endpoint<RegisterRequest, RegisterResponse>
{
    private readonly RegisterUserHandler _handler;

    public RegisterUserEndpoint(RegisterUserHandler handler)
    {
        _handler = handler;
    }

    public override async Task HandleAsync(RegisterRequest request, CancellationToken ct)
    {
        var result = await _handler.Handle(request);
            await SendOkAsync(result);     
    }
}
