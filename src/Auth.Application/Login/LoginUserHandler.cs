using Auth.Application.Exceptions;
using Auth.Application.Services;
using Auth.Application.Shared;
using Auth.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Serilog;

namespace Auth.Application.Login;

public class LoginUserHandler
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly ITokenService _tokenService;
    private readonly ILogger _logger;



    public LoginUserHandler(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        TokenService tokenService,
        ILogger logger)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
        _logger = logger;
    }

    public async Task<LoginResponse> Handle(LoginRequest request)
    {
        _logger.Information("Handling login request for user {UserIdentifier}", request.UserIdentifier);
        var user = await FindUser(request.UserIdentifier);
        ValidateLoginResult(await TryLogin(user, request.Password));
        var token = await _tokenService.GenerateJwt(user);
        UpdateUserRefreshToken(user, token);
        await _userManager.UpdateAsync(user);
        _logger.Information("User {UserIdentifier} logged in successfully", request.UserIdentifier);
        return new LoginResponse(token.AccessToken, token.RefreshToken, token.ExpiresInMinutes);
    }

    private async Task<ApplicationUser> FindUser(string userIdentifier)
    {
        var user = await _userManager.FindByNameAsync(userIdentifier) ??
                   await _userManager.FindByEmailAsync(userIdentifier);
        if (user == null)
        {
            _logger.Warning("User {UserIdentifier} not found", userIdentifier);
            throw ExceptionFactory.UserNotRegistered();
        }
        return user;
    }

    private async Task<SignInResult> TryLogin(ApplicationUser user, string password)
    {
        return await _signInManager.PasswordSignInAsync(user, password, false, true);
    }

    private void ValidateLoginResult(SignInResult result)
    {
        if (result.IsLockedOut)
        {
            throw ExceptionFactory.AccountLocked();
        }
        if (result.IsNotAllowed)
        {
            throw ExceptionFactory.UserNotConfirmed();
        }
        if (!result.Succeeded)
        {
            throw ExceptionFactory.InvalidLoginAttempt();
        }
    }

    private void UpdateUserRefreshToken(ApplicationUser user, TokenResponse token)
    {
        user.RefreshToken = token.RefreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddMinutes(token.RefreshTokenExpiresInMinutes);
    }

}
