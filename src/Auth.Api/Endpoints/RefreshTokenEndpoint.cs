using Auth.Application.RefreshToken;
using Auth.Application.Shared;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace Auth.Api.Endpoints;

[HttpPost("/refresh"), AllowAnonymous]
public class RefreshTokenEndpoint : Endpoint<RefreshTokenRequest, TokenResponse>
{
    private readonly RefreshTokenHandler _handler;

    public RefreshTokenEndpoint(RefreshTokenHandler handler)
    {
        _handler = handler;
    }

    public override async Task HandleAsync(RefreshTokenRequest request, CancellationToken ct)
    {
        var result = await _handler.Handle(request);
        await SendOkAsync(result);
    }
}           
