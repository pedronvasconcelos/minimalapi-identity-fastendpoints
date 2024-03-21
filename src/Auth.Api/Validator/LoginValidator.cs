using Auth.Application.Login;
using FastEndpoints;
using FluentValidation;

namespace Auth.Api.Validation;

public class LoginValidator : Validator<LoginRequest>
{
    public LoginValidator()
    {
        RuleFor(x => x.UserIdentifier)
            .NotEmpty()
            .WithMessage("UserIdentifier is required");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required");
    }
}