using Auth.Application.Exceptions;
using Auth.Application.Services;
using Auth.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Serilog;

namespace Auth.Application.Register;

public class RegisterUserHandler
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ITokenService _tokenService;
    private readonly ILogger _logger;
    public RegisterUserHandler(UserManager<ApplicationUser> userManager,
        ITokenService tokenService,
        ILogger logger)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _logger = logger;
    }

    public async Task<RegisterResponse> Handle(RegisterRequest request)
    {
        var user = new ApplicationUser(request.Username, request.Email);
        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            _logger.Warning("User registration failed for user {UserIdentifier}", request.Username);
            throw ExceptionFactory.RegistrationFailed(result.Errors);
        }
        _logger.Information("User {UserIdentifier} registered successfully", request.Username);
        var token = await _tokenService.GenerateJwt(user);
        return new RegisterResponse(true, "User created", token.AccessToken, token.RefreshToken, user.UserName, token.ExpiresInMinutes);
    }
}