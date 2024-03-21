using Auth.Application.Exceptions;
using Auth.Application.IdentitySettings;
using Auth.Application.Services;
using Auth.Application.Shared;
using Auth.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Serilog;
using System.Security.Claims;

namespace Auth.Application.RefreshToken;

public class RefreshTokenHandler
{
    private readonly ITokenService _tokenService;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ILogger _logger;
    public RefreshTokenHandler(ITokenService tokenService,
        UserManager<ApplicationUser> userManager,
        ILogger logger)
    {
        _tokenService = tokenService;
        _userManager = userManager;
        _logger = logger;
    }

    public async Task<TokenResponse> Handle(RefreshTokenRequest request)
    {
        ValidateRefreshToken(request.RefreshToken);
        var principal = GetPrincipalFromExpiredToken(request.Token);
        var user = await GetUser(principal.Identity?.Name ?? "");
        ValidateUserAndToken(user, request.RefreshToken);
        _logger.Information("Refreshing token for user {UserIdentifier}", user.UserName);
        return await GenerateNewTokensAndUpdateUser(user);
    }

    private void ValidateRefreshToken(string refreshToken)
    {
        if (string.IsNullOrEmpty(refreshToken))
        {
            throw ExceptionFactory.RefreshTokenRequired();
        }
    }

    private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        var principal = _tokenService.GetPrincipalFromExpiredToken(token);
        if (principal == null)
        {
            throw ExceptionFactory.InvalidToken();
        }
        return principal;
    }

    private async Task<ApplicationUser> GetUser(string username)
    {
        var user = await _userManager.FindByNameAsync(username);
        if (user == null)
        {
            throw ExceptionFactory.UserNotRegistered();
        }
        return user;
    }

    private void ValidateUserAndToken(ApplicationUser user, string refreshToken)
    {
        if (user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
        {
            throw ExceptionFactory.InvalidRefreshToken();
        }
    }

    private async Task<TokenResponse> GenerateNewTokensAndUpdateUser(ApplicationUser user)
    {
        var token = await _tokenService.GenerateJwt(user);
        user.RefreshToken = token.RefreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddMinutes(token.RefreshTokenExpiresInMinutes);
        await _userManager.UpdateAsync(user);
        return token;
    }

}
